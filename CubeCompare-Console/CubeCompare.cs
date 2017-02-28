/// ***************************************************************** 
/// File:        CubeCompare.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the CubeCompare class.
/// ***************************************************************** 

using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CubeCompare_Console
{
    /// <summary>
    /// Represents the comparision between two cubes via reports and 
    /// contains methods to retrieve the comparison in excel files.
    /// </summary>
    class CubeCompare
    {
        #region Variables
        /// <summary>
        /// 
        /// </summary>
        public CubeInfo Cube1 { get; }

        /// <summary>
        /// 
        /// </summary>
        public CubeInfo Cube2 { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<Report> Reports { get; }
        #endregion

        /// <summary>
        /// Constructs a CubeCompare object.
        /// </summary>
        /// <param name="cube1"></param>
        /// <param name="cube2"></param>
        /// <param name="reports"></param>
        public CubeCompare(CubeInfo cube1, CubeInfo cube2, List<Report> reports)
        {
            this.Cube1 = cube1;
            this.Cube2 = cube2;
            this.Reports = reports;
        }

        /// <summary>
        /// Validates the cubes and the reports and outputs any failures to console.
        /// </summary>
        /// <returns> 
        /// 0: Success
        /// 1: Failure
        /// </returns>
        public int validate()
        {
            // Check if objects are there
            if (Cube1 == null || Cube2 == null || Reports == null)
            {
                Console.WriteLine(Constants.failureMessages);
                return 1;
            }

            // Check if cube 1's connection is valid.
            int cubeConnectionResult1 = validateCubeConnection(Cube1);
            if ( cubeConnectionResult1 != 0)
            {
                return cubeConnectionResult1;
            }

            // Check if cube 2's connection is valid.
            int cubeConnectionResult2 = validateCubeConnection(Cube2);
            if (cubeConnectionResult2 != 0)
            {
                return cubeConnectionResult2;
            }

            return 0;
        }

        /// <summary>
        /// Validates a cube's connection parameters.
        /// </summary>
        /// <param name="cube"></param>
        /// <returns> 
        /// 0: Success
        /// 1: Failure
        /// </returns>
        private int validateCubeConnection(CubeInfo cube)
        {
            string connection = string.Format(Constants.dataSource, cube.Datasource, cube.Catalog);

            int errorCode = 0;
            bool cubeFound = false;
            try
            {
                using (AdomdConnection conn = new AdomdConnection(connection))
                {
                    conn.Open();

                    foreach (var c in conn.Cubes)
                    {
                        if (c.Name == cube.Cube)
                        {
                            cubeFound = true;
                        }
                    }

                    conn.Close();
                }
                if (!cubeFound)
                {
                    Console.WriteLine();
                    Console.WriteLine(string.Format(Constants.cubeMessage, cube.Cube, cube.Datasource, cube.Catalog));
                    Console.WriteLine();

                    errorCode = 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(string.Format(Constants.connectionMessage, cube.Datasource, cube.Catalog, cube.Cube));
                Console.WriteLine(string.Format(Constants.errorMessage, ex.Message));
                Console.WriteLine();
                errorCode = 1;
            }


            return errorCode;
        }

        /// <summary>
        /// Builds a command for a single attribute report.
        /// </summary>
        /// <param name="cube"></param>
        /// <param name="measures"></param>
        /// <param name="sliceByAttribute"></param>
        /// <param name="filters"></param>
        /// <param name="includeLabels"></param>
        /// <param name="timeRange"></param>
        /// <param name="timeDimension"></param>
        /// <returns></returns>
        private string commandBuilder(CubeInfo cube, List<string> measures, string sliceByAttribute, List<string> filters, bool includeLabels, CubeQueryTimeRange timeRange, string timeDimension)
        {
            string cmd;
            string subCube = string.Format("[{0}]", cube.Cube);
            char[] comma = { ',' };
            Dictionary<string, List<string>> attributeToFilters;

            if (!includeLabels)
            {
                cmd = "SELECT { ";
            }
            else
            {

                    cmd = string.Format(Constants.memberMessage, sliceByAttribute.Substring(0, sliceByAttribute.LastIndexOf('.')));  
            }

            foreach (string s in measures)
            {
                cmd += s + ",";
            }

           
            cmd = cmd.TrimEnd(comma);

            cmd += " } ON COLUMNS";

            if (includeLabels)
            {
                cmd += string.Format(Constants.allocateMessage, sliceByAttribute);
            }

            cmd += "  FROM";

            if (timeRange != null)
            {
                subCube = string.Format(Constants.selectMessage, 
                    timeDimension,timeRange.StartDate,timeDimension, timeRange.EndDate); ;
            }

            attributeToFilters = seperateMembersIntoHierarchies(filters);
            
            foreach (KeyValuePair<string, List<string>> kvp in attributeToFilters)
            {
                subCube = createSubCubeQuery(kvp.Value, subCube);
            }

            return cmd + subCube;
        
        }

        /// <summary>
        /// Seperates a list of attributes by their dimension.
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        private Dictionary<string, List<string>> seperateMembersIntoHierarchies(List<string> members)
        {
            Dictionary<string, List<string>> attributeToMember = new Dictionary<string, List<string>>();

            foreach (string s in members)
            {
                string[] parts = s.Split('.');
                string attribute = string.Format(Constants.formatMessage, parts[0], parts[1]);

                if (!attributeToMember.ContainsKey(attribute))
                {
                    attributeToMember.Add(attribute, new List<string>());
                }

                attributeToMember[attribute].Add(s);
            }

            return attributeToMember;
        }

        /// <summary>
        /// Creates a part of an MDX query. A subcube based on a set of members and another subcube.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="subCube"></param>
        /// <returns></returns>
        private string createSubCubeQuery(List<string> filters, string subCube)
        {
            char[] comma = { ',' };

            string cmd = "(  SELECT( { ";

            foreach (string s in filters)
            {
                cmd += s + ",";
            }

            cmd = cmd.TrimEnd(comma);

            return string.Format(Constants.subCubeQueryMessage, cmd, subCube);
        }

        /// <summary>
        /// Gets the MDX query from a Report and CubeInfo.
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="cube"></param>
        /// <returns></returns>
        private string getReportsCommand(Report rep, CubeInfo cube)
        {
            List<string> measures = new List<string>();
            measures.Add(rep.MeasureUniqueName);

            CubeQueryTimeRange cqtr;
            if (rep.TimeRange == null)
            {
                cqtr = cube.TimeRange;
            }
            else
            {
                cqtr = rep.TimeRange;
            }

            return commandBuilder(cube, measures, rep.SliceByAttribute, rep.FilterList, true, cqtr, getDefaultTimeDimension());
        }

        /// <summary>
        /// Gets the Time Dimension from Cube1, or Cube2 if Cube1 does not have one.
        /// </summary>
        /// <returns></returns>
        private string getDefaultTimeDimension()
        {
            if (Cube1.TimeRange == null)
                return Cube2.TimeDimension;
            return Cube1.TimeDimension;
        }

        /// <summary>
        /// Given a filePath, it will create an excel file which will contain the outputs of the given Reports.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="reportList"></param>
        private void queryReportsToSpreadsheet(string filePath, List<Report> reportList)
        {
            Utility.WriteToConsole(Constants.creatExcelDocMessage, 7);
            char[] charactersToRemove = { '[', ']' };

            // Setup Summery
            string summarySpreadSheetName = "Summary";
            ExcelManipulation.CreateExcelFile(filePath, summarySpreadSheetName);

            int percentageStyle = ExcelManipulation.GetStyleIndexOfDefaultPercentageFormatStyle(filePath);
            int commaNumberStyle = ExcelManipulation.GetStyleIndexOfDefaultCommaNumberFormatStyle(filePath);
            int startSummaryTable = 3;
            int endSummaryTable = startSummaryTable + 1;

            // Setup variables for inputing
            List<List<string>> summaryNumberBlock = new List<List<string>>();
            List<int> summaryStyles = new List<int>();
            List<List<string>> summaryTextBlock = new List<List<string>>();

            List<string> summaryReport = new List<string>();
            List<string> summaryMeasure = new List<string>();
            List<string> summarySlicer = new List<string>();
            List<string> summaryMember = new List<string>();
            List<string> summaryValue1 = new List<string>();
            List<string> summaryValue2 = new List<string>();
            List<string> summaryDifference = new List<string>();
            List<string> summaryPercentDifference = new List<string>();
            List<string> summaryHeader = new List<string>();

            summaryHeader.Add(Constants.report);
            summaryHeader.Add(Constants.measure);
            summaryHeader.Add(Constants.dimensionAttribute);
            summaryHeader.Add(Constants.memberRowLabels);
            summaryHeader.Add(string.Format("{0} {1} {2}", Cube1.Datasource, Cube1.Catalog, Cube1.Cube));
            summaryHeader.Add(string.Format("{0} {1} {2}", Cube2.Datasource, Cube2.Catalog, Cube2.Cube));
            summaryHeader.Add(Constants.difference);
            summaryHeader.Add(Constants.percentDifference);

            foreach (Report report in reportList)
            {
                // Create a spreadsheet
                Utility.WriteToConsole(string.Format(Constants.creatingSpreadsheet, report.ReportNumber), 5);
                string spreadSheetName = string.Format(Constants.reportNumber, report.ReportNumber);
                string titleMeasure = string.Join("", report.MeasureUniqueName.Split('.')[1].Split( charactersToRemove));
                string titleSlicer = string.Join("",(report.SliceByAttribute.Split('.')[0] + " " + report.SliceByAttribute.Split('.')[1]).Split(charactersToRemove));  
                string titleFilter = Constants.filter;
                string titleMDXQuery = string.Format(Constants.mdxQuery,getReportsCommand(report, Cube1));
                int tableRowStart = 5;

                int dataStyle;

                List<string> headers = new List<string>();
                headers.Add(report.SliceByAttribute);
                headers.Add(string.Format("{0} {1} {2}", Cube1.Datasource, Cube1.Catalog, Cube1.Cube));
                headers.Add(string.Format("{0} {1} {2}", Cube2.Datasource, Cube2.Catalog, Cube2.Cube));
                headers.Add(Constants.difference);
                headers.Add(Constants.percentDifference);

                foreach (string s in report.FilterList)
                {
                    titleFilter += s + ", ";
                }

                ExcelManipulation.CreateSpreadsheet(filePath, spreadSheetName);
                ExcelManipulation.InsertText(filePath, spreadSheetName, 1, Constants.A, titleMeasure);
                ExcelManipulation.InsertText(filePath, spreadSheetName, 2, Constants.A, titleSlicer);
                ExcelManipulation.InsertText(filePath, spreadSheetName, 3, Constants.A, titleFilter);
                ExcelManipulation.InsertText(filePath, spreadSheetName, 4, Constants.A, titleMDXQuery);
                ExcelManipulation.InsertRowText(filePath, spreadSheetName, (uint)tableRowStart, Constants.A, headers);
                ExcelManipulation.AddPercentageFormatColumn(filePath, spreadSheetName, 5); // Must be done before adding new values.



                // Query both cubes



                Utility.WriteToConsole(string.Format(Constants.query, report.MeasureUniqueName, report.SliceByAttribute, Cube1.Datasource, Cube1.Catalog, Cube1.Cube), 3);
               
                Dictionary<string, double> results1 = GetSlicedMeasureData(Cube1, getReportsCommand(report, Cube1));
                
                Utility.WriteToConsole(string.Format(Constants.query, report.MeasureUniqueName, report.SliceByAttribute, Cube2.Datasource, Cube2.Catalog, Cube2.Cube), 3);
                Dictionary<string, double> results2 = GetSlicedMeasureData(Cube2, getReportsCommand(report, Cube2));
                List<string> allMembers = results1.Keys.Union(results2.Keys).ToList();

                // Insert data into spreadsheet
                Utility.WriteToConsole(string.Format(Constants.insertingData, report.ReportNumber), 3);
                List<string> cube1Data = new List<string>();
                List<string> cube2Data = new List<string>();
                List<string> differenceData = new List<string>();
                List<string> percentageData = new List<string>();
                bool isDataAPercentage = false;

                for (int i = 0; i < allMembers.Count; i++)
                {
                    double value_1 = 0;
                    double value_2 = 0;
                    double percentDifference = 0;
                    double difference = 0;

                    if (results1.ContainsKey(allMembers[i]))
                    {
                        value_1 = results1[allMembers[i]];
                    }
                    if (results2.ContainsKey(allMembers[i]))
                    {
                        value_2 = results2[allMembers[i]];
                    }

                    difference = value_2 - value_1;

                    if (value_1 == 0)
                    {
                        if (value_2 != 0)
                            percentDifference = 1;
                    }
                    else
                    {
                        percentDifference = Math.Abs(difference) / value_1;
                    }

                    cube1Data.Add(Convert.ToString(value_1));
                    cube2Data.Add(Convert.ToString(value_2));
                    differenceData.Add(Convert.ToString(difference));
                    percentageData.Add(Convert.ToString(percentDifference));

                    // Check if data passes the report's threshold
                    if (report.Threshold.doesDataPassThreshold(allMembers[i], value_1, value_2, difference, percentDifference))
                    {
                        summaryReport.Add(string.Format(Constants.report, report.ReportNumber));
                        summaryMeasure.Add(titleMeasure);
                        summarySlicer.Add(titleSlicer);
                        summaryMember.Add(allMembers[i]);
                        summaryValue1.Add(value_1.ToString());
                        summaryValue2.Add(value_2.ToString());
                        summaryDifference.Add(difference.ToString());
                        summaryPercentDifference.Add(percentDifference.ToString());
                    }

                    // Check if any of the data is a percentage to determine how to format it.
                    if (value_1 != 0 && value_1 < 1)
                    {
                        isDataAPercentage = true;
                    }

                }
                // Insert all data, based on the determined format.
                if (isDataAPercentage) { dataStyle = percentageStyle; }
                else { dataStyle = commaNumberStyle; }

                List<List<string>> memberBlock = new List<List<string>>();
                memberBlock.Add(allMembers);

                List<List<string>> numberBlock = new List<List<string>>();
                numberBlock.Add(cube1Data);
                numberBlock.Add(cube2Data);
                numberBlock.Add(differenceData);
                numberBlock.Add(percentageData);

                List<int> styles = new List<int>();
                styles.Add(dataStyle);
                styles.Add(dataStyle);
                styles.Add(dataStyle);
                styles.Add(percentageStyle);

                ExcelManipulation.InsertBlockTextByColumn(filePath, spreadSheetName, (uint)tableRowStart + 1, Constants.A, memberBlock);
                ExcelManipulation.InsertBlockOfNumbersByColumns(filePath, spreadSheetName, (uint)tableRowStart + 1, Constants.B, numberBlock, styles);

                // Format spreadsheet
                Utility.WriteToConsole(string.Format(Constants.formattingReport, report.ReportNumber), 3);
                ExcelManipulation.AddConditionalFormattingColorScale(filePath, spreadSheetName, 2, Constants.ee); // Note that due to how the OpenXML standard requires specific ordering for XML items, Conditional formatting must be added before a table.                
                ExcelManipulation.AddTableToSpreadsheet(filePath, spreadSheetName, headers, string.Format(Constants.tableRange, (uint)tableRowStart, (allMembers.Count + (uint)tableRowStart).ToString()), string.Format(Constants.tableName, report.ReportNumber));
            }

            // Create summary
            Utility.WriteToConsole(Constants.creatingSummary, 3);

            ExcelManipulation.InsertText(filePath, summarySpreadSheetName, 1, Constants.A, Constants.cube1);
            ExcelManipulation.InsertText(filePath, summarySpreadSheetName, 1, Constants.B, string.Format("{0} {1} {2}", Cube1.Datasource, Cube1.Catalog, Cube1.Cube));
            ExcelManipulation.InsertText(filePath, summarySpreadSheetName, 2, Constants.A, Constants.cube2);
            ExcelManipulation.InsertText(filePath, summarySpreadSheetName, 2, Constants.B, string.Format("{0} {1} {2}", Cube2.Datasource, Cube2.Catalog, Cube2.Cube));
            
            summaryTextBlock.Add(summaryReport);
            summaryTextBlock.Add(summaryMeasure);
            summaryTextBlock.Add(summarySlicer);
            summaryTextBlock.Add(summaryMember);

            summaryNumberBlock.Add(summaryValue1);
            summaryNumberBlock.Add(summaryValue2);
            summaryNumberBlock.Add(summaryDifference);
            summaryNumberBlock.Add(summaryPercentDifference);

            summaryStyles.Add(-1);
            summaryStyles.Add(-1);
            summaryStyles.Add(-1);
            summaryStyles.Add(percentageStyle);

            ExcelManipulation.InsertRowText(filePath, summarySpreadSheetName, (uint)startSummaryTable, Constants.A, summaryHeader);
            ExcelManipulation.InsertBlockTextByColumn(filePath, summarySpreadSheetName, (uint)startSummaryTable + 1, Constants.A, summaryTextBlock);
            ExcelManipulation.InsertBlockOfNumbersByColumns(filePath, summarySpreadSheetName, (uint)startSummaryTable + 1, Constants.E, summaryNumberBlock, summaryStyles);

            if (summaryReport.Count() > 0)
                endSummaryTable = startSummaryTable + summaryReport.Count();

            ExcelManipulation.AddTableToSpreadsheet(filePath, summarySpreadSheetName, summaryHeader, string.Format(Constants.a3, endSummaryTable.ToString()), Constants.summaryTable);
        }

        /// <summary>
        /// Given a folderPath and foldername, will generate a single excel from the Reports.
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        public void queryReportsToSpreadsheet(string folderPath, string fileName)
        {
            string filePath = Utility.AddFiletofolderPath(folderPath, fileName + ".xlsx");

            queryReportsToSpreadsheet(filePath, Reports);
            
            Utility.WriteToConsole(Constants.completeReport, 7);
        }

        /// <summary>
        /// Given just a folderPath, will generate an excel file per acquistion group.
        /// </summary>
        /// <param name="folderPath"></param>
        public void queryReportsByAcquisitionGroup(string folderPath)
        {
            Dictionary<string, List<string>> cubeMeasuresByGroup = GetMeasureGroups(Cube1);
            Dictionary<string, List<Report>> reportsByMeasureGroup = new Dictionary<string, List<Report>>();

            Utility.WriteToConsole(Constants.retreiveMeasure, 7);

            foreach (KeyValuePair<string, List<string>> kvp in cubeMeasuresByGroup)
            {
                reportsByMeasureGroup.Add(kvp.Key, new List<Report>());

                foreach (Report rep in Reports)
                {
                    if (kvp.Value.Contains(rep.MeasureUniqueName))
                    {
                        reportsByMeasureGroup[kvp.Key].Add(rep);
                    }
                }
            }

            foreach (KeyValuePair<string, List<Report>> kvp in reportsByMeasureGroup)
            {
                if(kvp.Value.Count != 0)
                    queryReportsToSpreadsheet(Utility.AddFiletofolderPath(folderPath, kvp.Key + ".xlsx"), kvp.Value);
            }

            Utility.WriteToConsole(Constants.completeReport, 7);
        }

        /// <summary>
        /// Given a CubeInfo, will return a dictionary of measure group to list of measures in the cube.
        /// </summary>
        /// <param name="cubeInfo"></param>
        /// <returns></returns>
        private Dictionary<string, List<string>> GetMeasureGroups(CubeInfo cubeInfo)
        {
            Dictionary<string, List<string>> measureGroupsToMeasures = new Dictionary<string, List<string>>();


            string connection = string.Format(Constants.dataSource, cubeInfo.Datasource, cubeInfo.Catalog);
            AdomdConnection conn = new AdomdConnection(connection);
            conn.Open();

            CubeDef cubeDef = null;

            // Find cube in question.
            foreach (CubeDef cube in conn.Cubes)
            {
                if (cube.Name == cubeInfo.Cube)
                {
                    cubeDef = cube;
                }
            }

            foreach (Measure m in cubeDef.Measures)
            {
                Property p = m.Properties.Find(Constants.measureGroup);
                if (!measureGroupsToMeasures.ContainsKey(p.Value.ToString()))
                {
                    measureGroupsToMeasures.Add(p.Value.ToString(), new List<string>());
                }
                measureGroupsToMeasures[p.Value.ToString()].Add(m.UniqueName);
            }

            conn.Close();

            return measureGroupsToMeasures;
        }


        /// <summary>
        /// Returns a dictionary of row label to value retrieved from a query (command) applied to a cube (CubeInfo).
        /// </summary>
        /// <param name="cubeInfo"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public Dictionary<string, double> GetSlicedMeasureData(CubeInfo cubeInfo, string command)
        {
            Dictionary<string, double> datalist = new Dictionary<string, double>();

            string connection = cubeInfo.getStandardConnectionString();

            try
            {
                using (AdomdConnection conn = new AdomdConnection(connection))
                {
                    conn.Open();

                    using (AdomdCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = command;

                        using (AdomdDataReader result = cmd.ExecuteReader())
                        {
                            while (result.Read())
                            {
                                string label = "";
                                if (!result.IsDBNull(0))
                                {
                                    label = result[0].ToString();
                                }
                                double value = 0;
                                if (!result.IsDBNull(2))
                                    value = result.GetDouble(2);

                                datalist.Add(label, value);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (AdomdErrorResponseException aere)
            {
                Utility.WriteToConsole(string.Format(Constants.invalid, aere.Message) , 100);               
            }

            return datalist;
        }
    }
}
