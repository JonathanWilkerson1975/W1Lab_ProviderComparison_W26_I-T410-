Purpose
The purpose of this lab is to build foundational skills in provider-level database connectivity. These skills prepare you for ADO.NET development in Week 2 and Entity Framework Core work later in the quarter. By the end of this lab, you will:

Understand how SQLClient and ODBC connect to SQL Server
Recognize differences in connection-string syntax
Interpret and compare provider error messages
Document your observations in a structured format
Task
You will complete the following steps:

Create a .NET console project and add SQLClient + ODBC packages.
Run the provided SQLClient and ODBC connection tests.
Capture a screenshot of your console output showing both tests.
Explore variations in connection strings (timeout, credentials, parameter names).
Complete the Lab 1 Provider Comparison Worksheet included below.
Submit your screenshot + worksheet to Canvas under Lab 1.
Part 1 – Set Up Your Project
Step 1: Create the Console Project
Step 2: Add Required Packages
Step 3: Add the Provided Source Files
Part 2 – Run Provider Tests
Step 4: Run the Project
Step 5: Test a Valid Server Name
Part 3 – Explore Connection-String Variations
Variation 1: Timeout Parameter
Variation 2: Incorrect Credentials
Variation 3: ODBC Parameter Names
Part 4 – Lab 1 Worksheet (Complete & Submit)
Copy/paste the questions below into a document (DOCX or PDF) and answer each one based on your test results.

Lab 1 – Provider Comparison Worksheet
Your Name: ____________________________

Date: _________________________________

Which provider reported clearer error messages—SQLClient or ODBC? Why?

List two differences in parameter names between SQLClient and ODBC connection strings.

Which provider connected more reliably in your environment? Explain your setup.

If you were building a new .NET application targeting SQL Server, which provider would you choose and why?

Insert your screenshot here (console output):




End of Worksheet

Criteria for Success – Full Rubric (100 points)
Category	Points	Description of Success
SQLClient Test Output	30 pts	Screenshot shows SQLClient test attempts, including at least one successful connection OR clear troubleshooting steps attempted. Output must be readable.
ODBC Test Output	20 pts	Screenshot shows ODBC test attempt. Success is ideal but failure with visible error message is acceptable.
Worksheet Completeness	30 pts	All questions answered thoughtfully. Responses reference your actual observations rather than generic statements.
Connection-String Exploration	15 pts	Evidence that you attempted variations (timeout, credentials, parameter names). Discussion of results appears in your worksheet answers.
Professionalism / Clarity	5 pts	Submission is clear, organized, labeled, and readable.
Submission Instructions
Upload your screenshot (JPG, PNG, or PDF)
Upload your completed worksheet (DOCX or PDF)
Submit both files to Canvas under Lab 1
Lab 1 is now complete. Next: Week 1 Project Component.
