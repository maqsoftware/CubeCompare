/// ***************************************************************** 
/// File:        Constants.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the CubeCompare class.
/// ***************************************************************** 
namespace CubeCompare_Console
{
    /// <summary>
    /// 
    /// </summary>
    static class Constants
    {
        public static string failureMessages = "Failure loading from spreadsheet.";
        public static string dataSource = "DataSource = {0};Catalog = {1} ;";
        public static string cubeMessage = "Cube: {0} was not found in: {1} {2}.";
        public static string connectionMessage = "Connection: {0} {1} {2} is invalid.";
        public static string errorMessage = "Error Message: {0}";
        public static string memberMessage = "WITH MEMBER [Measures].[Label] AS {0}.CURRENTMEMBER.MEMBER_CAPTION SELECT {{ [Measures].[Label], ";
        public static string allocateMessage = ", {{ ({0}.ALLMEMBERS ) }} ON ROWS";
        public static string selectMessage = "(  SELECT( {0}.&{1} : {2}.&{3} ) ON COLUMNS FROM [Model] ) ";
        public static string formatMessage = "{0}.{1}";
        public static string subCubeQueryMessage = "{0} }} ) ON COLUMNS FROM {1} ) ";

        public static string report = "Report";
        public static string measure = "Measure";
        public static string dimensionAttribute = "Dimension - Attribute";
        public static string memberRowLabels = "Member (row labels)";
        public static string difference = "Difference";
        public static string percentDifference = "Percent Difference";
        public static string creatingSpreadsheet = "Creating spreadsheet for Report{0}. ";
        public static string reportNumber = "Report {0}";
        public static string filter = "Filters: ";
        public static string creatExcelDocMessage = "Creating Excel document";
        public static string mdxQuery = "MDX Query (Cube1): {0}";
        public static string query = "Querying {0} by attribute {1} for {2} {3} {4}.";

        public static string insertingData = "Inserting data into spreadsheet Report {0}. ";
        public static string formattingReport = "Formatting spreadsheet Report {0}. ";
        public static string A = "A";
        public static string B = "B";
        public static string ee = "E:E";
        public static string E = "E";
        public static string cube1 = "Cube 1";
        public static string cube2 = "Cube 2";
        public static string a3 = "A3:H{0}";
        public static string summaryTable = "Summary_table";
        public static string tableRange = "A{0}:E{1}";
        public static string tableName = "Report_{0}_table";

        public static string completeReport = "Completed report creation.";
        public static string retreiveMeasure = "Retrieving measure metadata for cube 1.";
        public static string measureGroup = "MEASUREGROUP_NAME";
        public static string invalid = "Invalid query.\nAdditional information:\n";
        public static string creatingSummary = "Creating summary.";

        public static string settingsLocation = "SettingsLocation";
        public static string missingSettings = "Missing settings filepath. Exiting application.";
        public static string loadingReport = "Loading report configurations from {0}";
        public static string usedByAnotherProcess = " because it is being used by another process";
        public static string additionalInfo = "Settings file is currently being used by another process.\n   \nAdditional information:\n {0}";
        public static string supportedExtension = "is not supported. Supported extensions are";
        public static string exception = "Settings file can not be found.\nFilepath must include the file's extention. \nAdditional information:\n {0}";
        public static string incorrectFormat = "Settings file in an incorrect format.\nPlease the following URL for the template of the settings file:\n___\nAdditional information:\n {0}";

        public static string settingFileNotFound = "Settings file can not be found. \nAdditional information:\n {0}";
        public static string failureLoading = "Failure loading settings file.";
        public static string validatingConnections = "Validating connections.";
        public static string failureValidatingConnections = "Failure validating connections.";
        public static string excelFilePerMeasure = "Excel file per measure group";
        public static string yes = "YES";
        public static string outputFolder = "Output Folder";

        public static string connection = "Connections";
        public static string settings = "Settings";
        public static string measures = "Measures";
        public static string rowLabel = "Row Labels";
        public static string filters = "Filters";
        public static string threshold = "Thresholds";
        public static string C = "C";
        public static string D= "D";
        public static string F = "F";
        public static string dateDimension = "Date Dimension";

      

        public static string dateYear = "[{0}-{1}-{2}T00:00:00]";

      

        public static char[] columnValues = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static string rgb1 = "FFFFEB84";
        public static string rgb2 = "FFFF0000";
        public static string numberFormat = "0.00%";
    }
}
