using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== W1 Lab: Provider Comparison & Connection Strings ===\n");

        Console.WriteLine("=== SQLClient Provider Test ===\n");
        TestSqlClient();

        Console.WriteLine("\n=== ODBC Provider Test ===\n");
        TestOdbc();

        Console.WriteLine("\n=== Connection String Variations ===\n");
        TestVariations();

        Console.WriteLine("\n=== Tests Complete ===");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void TestSqlClient()
    {
        try
        {
            // SQLClient connection string - try different options:
            // Option 1: Standard SQL Server
            string connectionString = "Server=localhost;Database=master;Trusted_Connection=true;";

            // Option 2: If you have SQL Express, try:
            // string connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=true;";

            // Option 3: If you have LocalDB, try:
            // string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=true;";

            Console.WriteLine($"SQLClient Connection String: {connectionString}");
            Console.WriteLine("Attempting connection...");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("✓ SQLClient: Connection SUCCESSFUL!");
                Console.WriteLine($"  Server Version: {connection.ServerVersion}");
                Console.WriteLine($"  Connection State: {connection.State}");
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("✗ SQLClient: Connection FAILED");
            Console.WriteLine($"  Error Type: {ex.GetType().Name}");
            Console.WriteLine($"  Error Message: {ex.Message}");

            // Check for specific error details
            if (ex is SqlException sqlEx)
            {
                Console.WriteLine($"  SQL Error Number: {sqlEx.Number}");
                Console.WriteLine($"  SQL Server: {sqlEx.Server}");
            }
        }
    }

    static void TestOdbc()
    {
        try
        {
            // ODBC connection string
            string connectionString = "Driver={ODBC Driver 17 for SQL Server};Server=localhost;Database=master;Trusted_Connection=yes;";

            // Alternative if ODBC Driver 17 not installed:
            // string connectionString = "Driver={SQL Server};Server=localhost;Database=master;Trusted_Connection=yes;";

            Console.WriteLine($"ODBC Connection String: {connectionString}");
            Console.WriteLine("Attempting connection...");

            using (var connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("✓ ODBC: Connection SUCCESSFUL!");
                Console.WriteLine($"  Connection State: {connection.State}");
                Console.WriteLine($"  Driver: {connection.Driver}");
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("✗ ODBC: Connection FAILED");
            Console.WriteLine($"  Error Type: {ex.GetType().Name}");
            Console.WriteLine($"  Error Message: {ex.Message}");

            // Check for specific ODBC error details
            if (ex is OdbcException odbcEx)
            {
                Console.WriteLine($"  ODBC Errors Count: {odbcEx.Errors.Count}");
                for (int i = 0; i < odbcEx.Errors.Count; i++)
                {
                    Console.WriteLine($"  Error {i + 1}: {odbcEx.Errors[i].Message}");
                }
            }
        }
    }

    static void TestVariations()
    {
        Console.WriteLine("--- Variation 1: Timeout Parameters ---");
        Console.WriteLine("  SQLClient uses: 'Connection Timeout=10'");
        Console.WriteLine("  ODBC uses: 'Timeout=10'");

        Console.WriteLine("\n--- Variation 2: Authentication Differences ---");
        Console.WriteLine("  SQLClient: 'Trusted_Connection=true'");
        Console.WriteLine("  ODBC: 'Trusted_Connection=yes'");
        Console.WriteLine("  SQLClient: 'User ID=sa;Password=pass'");
        Console.WriteLine("  ODBC: 'UID=sa;PWD=pass'");

        Console.WriteLine("\n--- Variation 3: Testing Invalid Server ---");
        TestInvalidServer();

        Console.WriteLine("\n--- Variation 4: Testing Wrong Credentials ---");
        TestWrongCredentials();
    }

    static void TestInvalidServer()
    {
        try
        {
            string invalidServerString = "Server=INVALID_SERVER_NAME;Database=master;Trusted_Connection=true;Connection Timeout=3;";
            Console.WriteLine($"  Testing SQLClient with invalid server...");

            using (var connection = new SqlConnection(invalidServerString))
            {
                connection.Open();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  SQLClient error for invalid server: {ex.Message.Substring(0, Math.Min(50, ex.Message.Length))}...");
        }
    }

    static void TestWrongCredentials()
    {
        try
        {
            string badCredsString = "Server=localhost;Database=master;User Id=wronguser;Password=wrongpass;";
            Console.WriteLine($"  Testing SQLClient with wrong credentials...");

            using (var connection = new SqlConnection(badCredsString))
            {
                connection.Open();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  SQLClient error for wrong credentials: {ex.Message.Substring(0, Math.Min(60, ex.Message.Length))}...");
        }
    }
}