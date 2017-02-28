/// ***************************************************************** 
/// File:        SettingsLoader.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains SettingsLoader class.
/// ***************************************************************** 
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CubeCompare_Console
{
    /// <summary>
    /// The SettingsLoader object loads connections, reports, and other settings from an excel file.
    /// </summary>
    class SettingsLoader
    {
        /// <summary>
        /// 
        /// </summary>
        private string settingfilePath;

        /// <summary>
        /// 
        /// </summary>
        public CubeCompare CubeComparison { get; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> Settings { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public SettingsLoader(string filePath)
        {

            this.settingfilePath = filePath;
            this.Settings = new Dictionary<string, string>();

            CubeInfo cube1 = null;
            CubeInfo cube2 = null;
            List<Report> reportList = new List<Report>();
            Dictionary<int, List<string>> filterMap = new Dictionary<int, List<string>>();
            Dictionary<int, string> measureMap = new Dictionary<int, string>();
            Dictionary<int, string> slicerMap = new Dictionary<int, string>();
            Dictionary<int, ReportThreshold> thresholdMap = new Dictionary<int, ReportThreshold>();

            List<string> blankMeasure = new List<string>();
            List<string> blankSlicers = new List<string>();
            List<string> blankFilters = new List<string>();
            ReportThreshold blankThreshold = null;

            // Get Workbook and worksheets from file.
            XLWorkbook workbook = new XLWorkbook(settingfilePath);
            IXLWorksheet connectionsWorksheet = workbook.Worksheet(Constants.connection);
            IXLWorksheet settingsSheet = workbook.Worksheet(Constants.settings);
            IXLWorksheet reports = workbook.Worksheet(Constants.measures);
            IXLWorksheet slicers = workbook.Worksheet(Constants.rowLabel);
            IXLWorksheet filters = workbook.Worksheet(Constants.filters);
            IXLWorksheet thresholds = workbook.Worksheet(Constants.threshold);

            // Get other settings
            foreach (IXLRangeRow r in settingsSheet.Tables.First().DataRange.RowsUsed())
            {
                this.Settings.Add(r.Cell(Constants.A).GetString(), r.Cell(Constants.B).GetString());
            }

            // Get CubeInfo information.
            foreach (IXLRangeRow r in connectionsWorksheet.Tables.First().DataRange.RowsUsed())
            {
                // Decide which cube will go first. The math is done something like cube2 - cube1 for difference.
                if ((int)r.Cell(Constants.A).GetDouble() == 1)
                {
                    cube1 = generateCubeInfoFromRow(r);
                }
                if ((int)r.Cell(Constants.A).GetDouble() == 2)
                {
                    cube2 = generateCubeInfoFromRow(r);
                }
            }

            // Get Report info
            // First get all filters
            foreach (IXLRangeRow r in filters.Tables.First().DataRange.RowsUsed())
            {
                if (r.Cell(Constants.A).IsEmpty())
                {
                    blankFilters.Add(r.Cell(Constants.B).GetString());
                }
                else
                {
                    List<int> reportNumbers = getNumbersFromString(r.Cell(Constants.A).GetString());

                    foreach (int num in reportNumbers)
                    {
                        if (!filterMap.ContainsKey(num))
                        {
                            filterMap.Add(num, new List<string>());
                        }
                        filterMap[num].Add(r.Cell(Constants.B).GetString());
                    }
                }
            }

            // Get the measures
            foreach (IXLRangeRow r in reports.Tables.First().DataRange.RowsUsed())
            {
                if (r.Cell(Constants.A).IsEmpty())
                {
                    blankMeasure.Add(r.Cell(Constants.B).GetString());
                }
                else
                {
                    List<int> reportNumbers = getNumbersFromString(r.Cell(Constants.A).GetString());
                    foreach (int num in reportNumbers)
                    {
                        measureMap.Add(num, r.Cell(Constants.A).GetString());
                    }
                }
                
            }

            // Get the slicers
            foreach (IXLRangeRow r in slicers.Tables.First().DataRange.RowsUsed())
            {
                if (r.Cell(Constants.A).IsEmpty())
                {
                    blankSlicers.Add(r.Cell(Constants.B).GetString());
                }
                else
                {
                    List<int> reportNumbers = getNumbersFromString(r.Cell(Constants.A).GetString());
                    foreach (int num in reportNumbers)
                    {
                        slicerMap.Add(num, r.Cell(Constants.B).GetString());
                    }
                }
            }

            // Get all thresholds
            foreach (IXLRangeRow r in thresholds.Tables.First().DataRange.RowsUsed())
            {
                if (r.Cell(Constants.A).IsEmpty())
                {
                    blankThreshold = new ReportThreshold(r.Cell(Constants.B).GetDouble(), r.Cell(Constants.C).GetDouble());
                }
                else
                {
                    List<int> reportNumbers = getNumbersFromString(r.Cell(Constants.A).GetString());
                    foreach (int num in reportNumbers)
                    {
                        thresholdMap.Add(num, new ReportThreshold(r.Cell(Constants.B).GetDouble(), r.Cell(Constants.C).GetDouble()));
                    }
                }
            }

            // Add all numbered reports
            foreach (KeyValuePair<int, string> kvp in measureMap)
            {
                Report report;
                List<string> repFilt;
                ReportThreshold repThres;

                if (filterMap.ContainsKey(kvp.Key))
                {
                    repFilt = filterMap[kvp.Key];
                }
                else
                {
                    repFilt =  new List<string>();
                }

                if (thresholdMap.ContainsKey(kvp.Key))
                {
                    repThres = thresholdMap[kvp.Key];
                }
                else
                {
                    repThres = null;
                }

                report = new Report(kvp.Key, kvp.Value, slicerMap[kvp.Key], repFilt, repThres);
                reportList.Add(report);
            }
            // Add unnumbered reports.
            int lastReportNumber = 0;
            if (measureMap.Count != 0)
            {
                lastReportNumber = measureMap.Keys.Max();
            }

            addBlankReportsToReportList(reportList, blankMeasure, blankSlicers, blankFilters, blankThreshold, lastReportNumber + 1);

            this.CubeComparison = new CubeCompare(cube1, cube2, reportList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reports"></param>
        /// <param name="blankMeasure"></param>
        /// <param name="blankSlicers"></param>
        /// <param name="blankFilters"></param>
        /// <param name="blankThreshold"></param>
        /// <param name="numberingStart"></param>
        private void addBlankReportsToReportList(List<Report> reports, List<string> blankMeasure, List<string> blankSlicers, List<string> blankFilters, ReportThreshold blankThreshold, int numberingStart)
        {
            int reportNumber = numberingStart;
            foreach (string measure in blankMeasure)
            {
                foreach (string slicer in blankSlicers)
                {
                    Report rep = new Report(reportNumber, measure, slicer, blankFilters, blankThreshold);

                    reports.Add(rep);

                    reportNumber++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private CubeInfo generateCubeInfoFromRow(IXLRangeRow row)
        {
            CubeInfo cube = new CubeInfo(row.Cell(Constants.B).GetString(), row.Cell(Constants.C).GetString(), row.Cell(Constants.D).GetString());

            if(!row.Cell(Constants.E).IsEmpty())
            { 
                cube.setTimeRange(new CubeQueryTimeRange(row.Cell(Constants.E).GetDateTime(), row.Cell(Constants.F).GetDateTime()), Settings[Constants.dateDimension]);
            }
            return cube;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private List<int> getNumbersFromString(string s)
        {
            List<int> numbers = new List<int>();
            string[] parts = s.Split(',');

            foreach (string p in parts)
            {
                if (p.Contains("-"))
                {
                    string[] bounds = p.Split('-');
                    for (int i = Convert.ToInt32(bounds[0]); i <= Convert.ToInt32(bounds[1]); i++)
                    {
                        numbers.Add(i);
                    }
                }
                else
                {
                    numbers.Add(Convert.ToInt32(p));
                }
            }
            return numbers;
        }
    }
}
