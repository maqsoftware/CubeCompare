/// ***************************************************************** 
/// File:        CubeCompareSettings.cs 
/// Project:     CubeCompare-GUI 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the CubeCompareSettings class, which loads
///              a settings file.
/// ***************************************************************** 

using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using System.Data;

namespace CubeCompare_GUI
{
    class CubeCompareSettings
    {

        public DataTable connections { get; set; }
        public DataTable measures { get; set; }
        public DataTable rowLabels { get; set; }
        public DataTable filters { get; set; }
        public DataTable thresholds { get; set; }
        public DataTable settings { get; set; }

        public CubeCompareSettings()
        {
            setupDataTables();
        }

        public CubeCompareSettings(string filePath)
        {
            setupDataTables();
            loadFrom(filePath);
        }

        private void setupDataTables()
        {
            this.connections = new DataTable();
            this.connections.TableName = Constants.connection;
            this.connections.Columns.Add(Constants.order, typeof(int));
            this.connections.Columns.Add(Constants.data, typeof(string));
            this.connections.Columns.Add(Constants.catalogue, typeof(string));
            this.connections.Columns.Add(Constants.cube, typeof(string));
            this.connections.Columns.Add(Constants.startDate, typeof(DateTime));
            this.connections.Columns.Add(Constants.endDate, typeof(DateTime));

            this.measures = new DataTable();
            this.measures.TableName = Constants.measures;
            this.measures.Columns.Add(Constants.reportNumber, typeof(int));
            this.measures.Columns.Add(  Constants.measureUnique, typeof(string));
            this.measures.Columns.Add(Constants.startDate, typeof(DateTime));
            this.measures.Columns.Add(Constants.endDate, typeof(DateTime));

            this.rowLabels = new DataTable();
            this.rowLabels.TableName = Constants.rowLabel;
            this.rowLabels.Columns.Add(Constants.reportNumber, typeof(int));
            this.rowLabels.Columns.Add(Constants.attributeLevelUniqueName, typeof(string));

            this.filters = new DataTable();
            this.filters.TableName = Constants.filter;
            this.filters.Columns.Add(Constants.reportNumber, typeof(int));
            this.filters.Columns.Add(Constants.filter, typeof(string));

            this.thresholds = new DataTable();
            this.thresholds.TableName = Constants.threshold;
            this.thresholds.Columns.Add(Constants.reportNumber, typeof(int));
            this.thresholds.Columns.Add(Constants.maximumDiff, typeof(int));
            this.thresholds.Columns.Add(Constants.maximumPercentage, typeof(double));

            this.settings = new DataTable();
            this.settings.TableName = Constants.settings;
            this.settings.Columns.Add(Constants.setting, typeof(string));
            this.settings.Columns.Add(Constants.value, typeof(string));
        }

        public void saveTo(string filePath)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                IXLWorksheet connectionsWS = workbook.Worksheets.Add(connections);
                IXLWorksheet measuresWS = workbook.Worksheets.Add(measures);
                IXLWorksheet rowLabelsWS = workbook.Worksheets.Add(rowLabels);
                IXLWorksheet filtersWS = workbook.Worksheets.Add(filters);
                IXLWorksheet thresholdsWS = workbook.Worksheets.Add(thresholds);
                IXLWorksheet settingsWS = workbook.Worksheets.Add(settings);

                workbook.SaveAs(filePath);
            }
        }

        public void addmeasures(List<string> measureUniqueNames)
        {
            foreach (string s in measureUniqueNames)
            {
                measures.Rows.Add(null, s, null, null);
            }
        }

        public void addrowLabels(List<string> measureUniqueNames)
        {
            foreach (string s in measureUniqueNames)
            {
                rowLabels.Rows.Add(null, s);
            }
        }

        public void addfilters(List<string> filterNames)
        {
            foreach (string s in filterNames)
            {
                filters.Rows.Add(null, s);
            }
        }

        private void loadFrom(string filePath)
        {
            using (XLWorkbook wb = new XLWorkbook(filePath))
            {
                loadSpreadsheetIntoADatatable(wb, Constants.connection, connections);
                loadSpreadsheetIntoADatatable(wb, Constants.measures, measures);
                loadSpreadsheetIntoADatatable(wb, Constants.rowLabel, rowLabels);
                loadSpreadsheetIntoADatatable(wb, Constants.filter, filters);
                loadSpreadsheetIntoADatatable(wb, Constants.threshold, thresholds);
                loadSpreadsheetIntoADatatable(wb, Constants.settings, settings);
            }
        }


        public void loadSpreadsheetIntoADatatable(XLWorkbook workbook, string spreadSheetName, DataTable dTable)
        {
            IXLWorksheet ws = workbook.Worksheet(spreadSheetName);

            try
            {
                foreach (IXLRangeRow rows in ws.Tables.First().DataRange.RowsUsed())
                {
                    dTable.Rows.Add();

                    int index = 0;
                    foreach (IXLCell c in rows.Cells())
                    {
                        try
                        {
                            if (c.GetString() != "")
                            {
                                dTable.Rows[dTable.Rows.Count - 1][index] = c.GetString();
                            }
                        }
                        catch (ArgumentException e)
                        {
                            try
                            {
                                if (e.Message.Contains("Int32"))
                                {
                                    dTable.Rows[dTable.Rows.Count - 1][index] = Convert.ToInt32(c.GetString());
                                }
                                else
                                {
                                    throw e;
                                }
                            }
                            catch (FormatException fe)
                            {
                                Exception ex = new Exception(string.Format(Constants.inputInvalidFormat, spreadSheetName, c.Address.ToString()), fe);
                                throw ex;
                            }
                        }
                        index++;
                    }
                }
            }
            catch (Exception e)
            {
                if (ws.Tables.Count() == 0)
                {
                    Exception ex = new Exception(string.Format(Constants.missingTable, spreadSheetName), e);
                    throw ex;
                }
                else
                {
                    throw e;
                }
            }
        }

    }
}
