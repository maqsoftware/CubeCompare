/// ***************************************************************** 
/// File:        ExcelManipulation.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the ExcelManipulation class.
/// ***************************************************************** 

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CubeCompare_Console
{


    /// <summary>
    /// Uses OpenXML to perform manipulation of excel files.
    /// </summary>
    class ExcelManipulation
    {
        /// <summary>
        /// 
        /// </summary>
        private static char[] columnValues =  Constants.columnValues;       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        /// <param name="displayPriority"></param>
        /// <param name="range"></param>
        // Note: will currently break if adding when conditional formatting already exists.
        public static void AddConditionalFormattingColorScale(string filePath, string sheetName, int displayPriority, string range)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, sheetName);

                ConditionalFormatting cf = new ConditionalFormatting();

                ConditionalFormattingRule cfr = new ConditionalFormattingRule();

                cfr.Priority = displayPriority;
                cfr.Type = ConditionalFormatValues.ColorScale;


                ColorScale cs = new ColorScale();

                ConditionalFormatValueObject cfvo1 = new ConditionalFormatValueObject();
                cfvo1.Type = ConditionalFormatValueObjectValues.Max;

                ConditionalFormatValueObject cfvo2 = new ConditionalFormatValueObject();
                cfvo2.Type = ConditionalFormatValueObjectValues.Percentile;
                cfvo2.Val = new StringValue("50");

                ConditionalFormatValueObject cfvo3 = new ConditionalFormatValueObject();
                cfvo3.Type = ConditionalFormatValueObjectValues.Min;

                Color theme = new Color();
                theme.Theme = 9;

                Color color1 = new Color();
                color1.Rgb = Constants.rgb1;
                Color color2 = new Color();
                color2.Rgb = Constants.rgb2;


                cs.AppendChild(cfvo1);
                cs.AppendChild(cfvo2);
                cs.AppendChild(cfvo3);
                cs.AppendChild(theme);
                cs.AppendChild(color1);
                cs.AppendChild(color2);

                DocumentFormat.OpenXml.ListValue<StringValue> cells = new DocumentFormat.OpenXml.ListValue<StringValue>();
                cells.Items.Add(range);

                cf.SequenceOfReferences = cells;

                cfr.AppendChild(cs);
                cf.AppendChild(cfr);
                wsPart.Worksheet.AppendChild(cf);

                wsPart.Worksheet.Save();
                    
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="columnIndex"></param>
        public static void AddPercentageFormatColumn(string filePath, string spreadSheetName, int columnIndex)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                string numberFormat = Constants.numberFormat;
                UInt32 numberFormattingIndex = 10;

                CellFormat c = new CellFormat { NumberFormatId = numberFormattingIndex, FontId = 0, BorderId = 0, FillId = 0, ApplyNumberFormat = BooleanValue.FromBoolean(true) };

                int styleIndex = AddStyle(excelFile.WorkbookPart, c);

                AddNumberingFormatToStylesheet(excelFile.WorkbookPart, numberFormattingIndex, numberFormat);

                Column col = new Column();
                col.Min = Convert.ToUInt32(columnIndex);
                col.Max = Convert.ToUInt32(columnIndex);
                col.Style = Convert.ToUInt32(styleIndex);
                col.CustomWidth = true;
                col.Width = 10;


                Columns cols = wsPart.Worksheet.GetFirstChild<Columns>();
                if (cols == null)
                {
                    cols = new Columns();
                    wsPart.Worksheet.PrependChild(cols);
                }
                cols.Append(col);
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int GetStyleIndexOfDefaultPercentageFormatStyle(string filePath)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {

                Stylesheet ss = GetStyleSheet(excelFile.WorkbookPart);

               
                for (int i = 0; i < ss.CellFormats.Count(); i++)
                {
                    CellFormat cf = (CellFormat)ss.CellFormats.ElementAt(i);
                    if ( cf.ApplyNumberFormat != null && cf.ApplyNumberFormat == true && cf.NumberFormatId == 10 && cf.FontId == 0 && cf.FillId == 0 && cf.BorderId == 0)
                    {
                        return i;
                    }
                }

                string numberFormat = Constants.numberFormat;
                UInt32 numberFormattingIndex = 10;

                AddNumberingFormatToStylesheet(excelFile.WorkbookPart, numberFormattingIndex, numberFormat);

                CellFormat c = new CellFormat { NumberFormatId = numberFormattingIndex, FontId = 0, BorderId = 0, FillId = 0, ApplyNumberFormat = BooleanValue.FromBoolean(true) };

                return AddStyle(excelFile.WorkbookPart, c);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int GetStyleIndexOfDefaultCommaNumberFormatStyle(string filePath)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                //Defaults for this type.
                string numberFormat = "#,##0";
                UInt32 numberFormattingIndex = 3;

                Stylesheet ss = GetStyleSheet(excelFile.WorkbookPart);

                for (int i = 0; i < ss.CellFormats.Count(); i++)
                {
                    CellFormat cf = (CellFormat)ss.CellFormats.ElementAt(i);
                    if (cf.ApplyNumberFormat != null && cf.ApplyNumberFormat == true && cf.NumberFormatId == numberFormattingIndex && cf.FontId == 0 && cf.FillId == 0 && cf.BorderId == 0)
                    {
                        return i;
                    }
                }

                AddNumberingFormatToStylesheet(excelFile.WorkbookPart, numberFormattingIndex, numberFormat);

                CellFormat c = new CellFormat { NumberFormatId = numberFormattingIndex, FontId = 0, BorderId = 0, FillId = 0, ApplyNumberFormat = BooleanValue.FromBoolean(true) };

                return AddStyle(excelFile.WorkbookPart, c);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workbookPart"></param>
        /// <param name="numFormatIndex"></param>
        /// <param name="numberFormat"></param>
        private static void AddNumberingFormatToStylesheet(WorkbookPart workbookPart, UInt32 numFormatIndex, string numberFormat)
        {

            Stylesheet ss = GetStyleSheet(workbookPart);

            if (ss.NumberingFormats == null)
            {
                ss.NumberingFormats = new NumberingFormats() { Count = 0 };
            }

            ss.NumberingFormats.Append(new NumberingFormat() { NumberFormatId = numFormatIndex, FormatCode = numberFormat });
            ss.NumberingFormats.Count += 1;

            ss.Save();
            workbookPart.Workbook.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wbPart"></param>
        /// <param name="cFormat"></param>
        /// <returns></returns>
        private static int AddStyle(WorkbookPart wbPart, CellFormat cFormat)
        {
            Stylesheet ss = GetStyleSheet(wbPart);

            ss.CellFormats.Append(cFormat);
            ss.CellFormats.Count += 1;

            return ss.CellFormats.Count() - 1;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wbPart"></param>
        /// <returns></returns>
        private static Stylesheet GetStyleSheet(WorkbookPart wbPart)
        {
            if (wbPart.WorkbookStylesPart == null)
            {
                WorkbookStylesPart tempWSTPart = wbPart.AddNewPart<WorkbookStylesPart>();
                tempWSTPart.Stylesheet = CreateDefaultStylesheet();
                wbPart.Workbook.Save();
                tempWSTPart.Stylesheet.Save();
            }
            return wbPart.WorkbookStylesPart.Stylesheet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // A stylesheet must have a font, a fill, a border, and cell format set, if any of them are set.
        private static Stylesheet CreateDefaultStylesheet()
        {
            var sSheet = new Stylesheet();

            // Create a font based on default font.
            var fts = new Fonts() { Count = 1, KnownFonts = true };
            var ft = new Font
            {
                FontSize = new FontSize() { Val = 11 },
                FontName = new FontName { Val = "Calibri" },
                FontFamilyNumbering = new FontFamilyNumbering() { Val = 2 },
                FontScheme = new FontScheme() { Val = FontSchemeValues.Major }
            };

            // Append Fonts to Stylesheet
            fts.Append(ft);
            sSheet.Append(fts);

            // Create a fill based on default fill
            var fls = new Fills() { Count = 1 };
            var fl = new Fill();
            fl.PatternFill = new PatternFill { PatternType = PatternValues.None };

            // Append Fills to Stylesheet
            fls.Append(fl);
            sSheet.Append(fls);

            // Create a border based on the default border
            var brds = new Borders() { Count = 1 };
            var brd = new Border()
            {
                LeftBorder = new LeftBorder(),
                RightBorder = new RightBorder(),
                TopBorder = new TopBorder(),
                BottomBorder = new BottomBorder(),
                DiagonalBorder = new DiagonalBorder()
            };

            // Append Borders to Stylesheet
            brds.Append(brd);
            sSheet.Append(brds);

            // Create a cell format with input numbering format
            var cFormats = new CellFormats { Count = 1 };

            var defaultCFormat = new CellFormat { NumberFormatId = 0, FormatId = 0, FontId = 0, BorderId = 0, FillId = 0 };

            // Append Cellformats to stylesheet
            cFormats.Append(defaultCFormat);

            sSheet.Append(cFormats);

            return sSheet;
            
        }
           
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="columns"></param>
        /// <param name="tableRange"></param>
        /// <param name="tableName"></param>
        public static void AddTableToSpreadsheet(string filePath, string spreadSheetName, List<string> columns, string tableRange, string tableName)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                // Get neccesary variables
                string tableID;
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);
                TableParts tParts = GetTableParts(wsPart, spreadSheetName);
                TableDefinitionPart tdPart = CreateTableDefinitionPart(wsPart, spreadSheetName, (int)((uint)tParts.Count + 1), out tableID);

                int countOfTables = 0;
                foreach (WorksheetPart wp in excelFile.WorkbookPart.WorksheetParts)
                {
                    countOfTables += wp.TableDefinitionParts.Count();
                }

                // Define the table
                Table tbl = new Table() { Id = (uint)countOfTables, Name = tableName, DisplayName = tableName, Reference = tableRange, TotalsRowShown = false };
                AutoFilter aFilter = new AutoFilter() { Reference = tableRange };
                TableColumns tColumns = new TableColumns() { Count = Convert.ToUInt32(columns.Count) };

                for (int i = 0; i < columns.Count; i++)
                {
                    tColumns.Append(new TableColumn() { Id = Convert.ToUInt32(i + 1), Name = columns[i] });
                }

                TableStyleInfo tsInfo = new TableStyleInfo() { Name = "TableStyleMedium2", ShowFirstColumn = false, ShowLastColumn = false, ShowRowStripes = true, ShowColumnStripes = false };
                
                tbl.Append(aFilter);
                tbl.Append(tColumns);
                tbl.Append(tsInfo);
                tdPart.Table = tbl;
               
                // Add reference to worksheet
                TablePart tPart = new TablePart() { Id = tableID };
                tParts.Count++;
                tParts.Append(tPart);

                // Save changes
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wsPart"></param>
        /// <param name="spreadSheetName"></param>
        /// <returns></returns>
        private static TableParts GetTableParts(WorksheetPart wsPart, string spreadSheetName)
        {
            if (wsPart.Worksheet.GetFirstChild<TableParts>() == null)
            {
                TableParts tParts = new TableParts() { Count = 0 };
                wsPart.Worksheet.Append(tParts);
                wsPart.Worksheet.Save();
                return tParts;
            }
            return wsPart.Worksheet.GetFirstChild<TableParts>();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wsPart"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="worksheetSpecificTableID"></param>
        /// <param name="tableId"></param>
        /// <returns></returns>
        private static TableDefinitionPart CreateTableDefinitionPart(WorksheetPart wsPart, string spreadSheetName, int worksheetSpecificTableID, out string tableId)
        {
            tableId = "rId" + worksheetSpecificTableID.ToString();
            
            return wsPart.AddNewPart<TableDefinitionPart>(tableId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateExcelFile(string filePath)
        {
            CreateExcelFile(filePath, "Sheet1");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public static void CreateExcelFile(string filePath, string sheetName)
        {
            // Create a spreadsheet document by supplying the filePath.
            // By default, AutoSave = true, Editable = true, and Type = xlsx.
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook);
            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = sheetName };
            sheets.Append(sheet);
            workbookpart.Workbook.Save();
            // Close the document.
            spreadsheetDocument.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /* * * * * * * *
         * Reference: https://msdn.microsoft.com/en-us/library/office/documentformat.openxml.spreadsheet.sheet.aspx 
         * * * * * * * * */
        public static void CreateSpreadsheet(string filePath, string spreadSheetName)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                // Get a Unique Sheet id
                long newSheetID = 1;

                foreach (Sheet s in excelFile.WorkbookPart.Workbook.Sheets)
                {
                    newSheetID = Math.Max(s.SheetId + 1, newSheetID);
                }

                // Create a new worksheet part for the worksheet.
                WorksheetPart worksheetPart = excelFile.WorkbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Create a new sheet
                Sheet sheet = new Sheet()
                {
                    Id = excelFile.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = Convert.ToUInt32(newSheetID),
                    Name = spreadSheetName
                };

                // Append the sheet to the workbook and save.
                excelFile.WorkbookPart.Workbook.Sheets.Append(sheet);
                excelFile.WorkbookPart.Workbook.Save();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="text"></param>
        public static void InsertText(string filePath, string spreadSheetName, uint row, string column, string text)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                // Insert some text into the shared string table, get index to put into cell.
                int sstIndex = InsertTextInSharedStringTable(text, GetSharedStringTablePart(excelFile));

                // Retrieve the worksheetpart of the spreadsheet
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                // Insert a cell into the worksheet, get the Cell object to assign properties to it.
                Cell excelCell = InsertCellIntoWorksheet(wsPart, column, row);

                // Put the shared string table index as the cell value, and set its type to shared string
                // so that the program looks at the shared string table for the actual value.
                excelCell.CellValue = new CellValue(sstIndex.ToString());
                excelCell.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                // Save the workbook/worksheet.
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="values"></param>
        public static void InsertRowText(string filePath, string spreadSheetName, uint startingRow, string startingColumn, List<string> values)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                string currentColumn = startingColumn;
                // Retrieve the worksheetpart of the spreadsheet
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                foreach (string s in values)
                {
                    // Insert some text into the shared string table, get index to put into cell.
                    int sstIndex = InsertTextInSharedStringTable(s, GetSharedStringTablePart(excelFile));

                    // Insert a cell into the worksheet, get the Cell object to assign properties to it.
                    Cell excelCell = InsertCellIntoWorksheet(wsPart, currentColumn, startingRow);

                    // Put the shared string table index as the cell value, and set its type to shared string
                    // so that the program looks at the shared string table for the actual value.
                    excelCell.CellValue = new CellValue(sstIndex.ToString());
                    excelCell.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                    currentColumn = GetNextColumn(currentColumn);

                }

                // Save the workbook/worksheet.
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="values"></param>
        public static void InsertColumnText(string filePath, string spreadSheetName, uint startingRow, string startingColumn, List<string> values)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                uint currentRow = startingRow;
                // Retrieve the worksheetpart of the spreadsheet
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                foreach (string s in values)
                {
                    // Insert some text into the shared string table, get index to put into cell.
                    int sstIndex = InsertTextInSharedStringTable(s, GetSharedStringTablePart(excelFile));

                    // Insert a cell into the worksheet, get the Cell object to assign properties to it.
                    Cell excelCell = InsertCellIntoWorksheet(wsPart, startingColumn, currentRow);

                    // Put the shared string table index as the cell value, and set its type to shared string
                    // so that the program looks at the shared string table for the actual value.
                    excelCell.CellValue = new CellValue(sstIndex.ToString());
                    excelCell.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                    currentRow++;

                }

                // Save the workbook/worksheet.
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// Optimized text insert.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="values"></param>
        public static void InsertBlockTextByColumn(string filePath, string spreadSheetName, uint startingRow, string startingColumn, List<List<string>> columns)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                
                // Retrieve the worksheetpart of the spreadsheet
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                // Flattens the list and gives it to the shared string table indexer.
                Dictionary<string, int> ssIndexes = InsertListOfTextInSharedStringTable(columns.SelectMany( x => x).ToList(),GetSharedStringTablePart(excelFile));

                List<List<Cell>> cellsByCol = InsertBlockOfCellsIntoWorksheetByColumns(wsPart, startingColumn, startingRow, columns.Count, columns[0].Count);

                string currentCol = startingColumn;
                for(int i = 0; i < columns.Count; i++)
                {
                    uint currentRow = startingRow;

                    for (int j = 0; j < columns[i].Count; j++)
                    {

                        // Put the shared string table index as the cell value, and set its type to shared string
                        // so that the program looks at the shared string table for the actual value.
                        cellsByCol[i][j].CellValue = new CellValue(ssIndexes[columns[i][j]].ToString());
                        cellsByCol[i][j].DataType = new EnumValue<CellValues>(CellValues.SharedString);

                        currentRow++;
                    }
                    currentCol = GetNextColumn(currentCol);
                }

                // Save the workbook/worksheet.
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="values"></param>
        public static void InsertRowNumbers(string filePath, string spreadSheetName, uint startingRow, string startingColumn, List<string> values)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                string currentColumn = startingColumn;
                // Retrieve the worksheetpart of the spreadsheet
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                foreach (string s in values)
                {

                    // Insert a cell into the worksheet, get the Cell object to assign properties to it.
                    Cell excelCell = InsertCellIntoWorksheet(wsPart, currentColumn, startingRow);

                    // Put the shared string table index as the cell value, and set its type to shared string
                    // so that the program looks at the shared string table for the actual value.
                    excelCell.CellValue = new CellValue(s);
                    excelCell.DataType = new EnumValue<CellValues>(CellValues.Number);

                    currentColumn = GetNextColumn(currentColumn);

                }

                // Save the workbook/worksheet.
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="values"></param>
        public static void InsertColumnNumbers(string filePath, string spreadSheetName, uint startingRow, string startingColumn, List<string> values)
        {
            InsertColumnNumbers(filePath, spreadSheetName, startingRow, startingColumn, values, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="values"></param>
        public static void InsertColumnNumbersWithDynamicFormatting(string filePath, string spreadSheetName, uint startingRow, string startingColumn, List<string> values)
        {
            // Get the style nesseccary.
            int percentStyle = GetStyleIndexOfDefaultPercentageFormatStyle(filePath);
            int numberCommaStyle = GetStyleIndexOfDefaultCommaNumberFormatStyle(filePath);

            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                uint currentRow = startingRow;
                // Retrieve the worksheetpart of the spreadsheet
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                foreach (string s in values)
                {
                    // Find style based on what type of number it is.
                    int style = 0;
                    if (Math.Abs(Convert.ToDouble(s)) < 1 && Convert.ToDouble(s) != 0)
                    {
                        style = percentStyle;
                    }
                    else
                    {
                        style = numberCommaStyle;
                    }

                    // Insert a cell into the worksheet, get the Cell object to assign properties to it.
                    Cell excelCell = InsertCellIntoWorksheet(wsPart, startingColumn, currentRow);

                    // Put the shared string table index as the cell value, and set its type to shared string
                    // so that the program looks at the shared string table for the actual value.
                    excelCell.CellValue = new CellValue(s);
                    excelCell.DataType = new EnumValue<CellValues>(CellValues.Number);

                    if (style != 0)
                    {
                        excelCell.StyleIndex = (uint)style;
                    }

                    currentRow++;

                }

                // Save the workbook/worksheet.
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="values"></param>
        /// <param name="style"></param>
        public static void InsertColumnNumbers(string filePath, string spreadSheetName, uint startingRow, string startingColumn, List<string> values, int style)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                uint currentRow = startingRow;
                // Retrieve the worksheetpart of the spreadsheet
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                foreach (string s in values)
                {

                    // Insert a cell into the worksheet, get the Cell object to assign properties to it.
                    Cell excelCell = InsertCellIntoWorksheet(wsPart, startingColumn, currentRow);

                    // Put the shared string table index as the cell value, and set its type to shared string
                    // so that the program looks at the shared string table for the actual value.
                    excelCell.CellValue = new CellValue(s);
                    excelCell.DataType = new EnumValue<CellValues>(CellValues.Number);

                    if (style != 0)
                    {
                        excelCell.StyleIndex = (uint)style;
                    }

                    currentRow++;

                }

                // Save the workbook/worksheet.
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// An insert of a block of numbers. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="values">A list of columns in list form.</param>
        /// <param name="styles"> The styles of each column. 0 is default, -1 is dynamic.</param>
        public static void InsertBlockOfNumbersByColumns(string filePath, string spreadSheetName, uint startingRow, string startingColumn, List<List<string>> values, List<int> styles)
        {
            // Get the style nesseccary.
            uint percentStyle = (uint)GetStyleIndexOfDefaultPercentageFormatStyle(filePath);
            uint numberCommaStyle = (uint)GetStyleIndexOfDefaultCommaNumberFormatStyle(filePath);

            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {
                // Retrieve the worksheetpart of the spreadsheet
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                List<List<Cell>> excelCells = InsertBlockOfCellsIntoWorksheetByColumns(wsPart, startingColumn, startingRow, values.Count, values[0].Count);


                string currentCol = startingColumn;
                for (int i = 0; i < values.Count; i++)
                {
                    uint currentRow = startingRow;

                    for (int j = 0; j < values[i].Count; j++)
                    {

                        // Put the shared string table index as the cell value, and set its type to shared string
                        // so that the program looks at the shared string table for the actual value.
                        excelCells[i][j].CellValue = new CellValue(values[i][j]);
                        excelCells[i][j].DataType = new EnumValue<CellValues>(CellValues.Number);

                        if (styles[i] == -1)
                        {
                            double s = Convert.ToDouble(values[i][j]);
                            if (Math.Abs(s) < 1 && s != 0)
                            {
                                excelCells[i][j].StyleIndex = percentStyle;
                            }
                            else
                            {
                                excelCells[i][j].StyleIndex = numberCommaStyle;
                            }
                        }
                        else if (styles[i] != 0)
                        {
                            excelCells[i][j].StyleIndex = (uint)styles[i];
                        }

                        currentRow++;
                    }
                    currentCol = GetNextColumn(currentCol);
                }

                // Save the workbook/worksheet.
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string GetNextColumn(string column)
        {
            
            string returnColumn;

            if (column.Length == 0)
                return "A";
            else if (column.Last() == 'Z')
                return GetNextColumn(column.Substring(0,column.Length - 1)) + "A";
            else
            {
                returnColumn = column.Substring(0, column.Length - 1);

                int index = 0;

                for (int i = 0; i < columnValues.Length; i++)
                {
                    if (columnValues[i] == column.Last())
                    {
                        index = i + 1;
                        break;
                    }
                }
                return returnColumn + columnValues[index];
            }
                
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public static void InsertNumber(string filePath, string spreadSheetName, uint row, string column, string value)
        {
            InsertNumber(filePath, spreadSheetName, row, column, value, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="spreadSheetName"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="style"></param>
        public static void InsertNumber(string filePath, string spreadSheetName, uint row, string column, string value, int style)
        {
            using (SpreadsheetDocument excelFile = SpreadsheetDocument.Open(filePath, true))
            {

                // Retrieve the worksheetpart of the spreadsheet
                WorksheetPart wsPart = GetWorkSheetPartByName(excelFile, spreadSheetName);

                // Insert a cell into the worksheet, get the Cell object to assign properties to it.
                Cell excelCell = InsertCellIntoWorksheet(wsPart, column, row);

                // Put the shared string table index as the cell value, and set its type to shared string
                // so that the program looks at the shared string table for the actual value.
                excelCell.CellValue = new CellValue(value);
                excelCell.DataType = new EnumValue<CellValues>(CellValues.Number);

                if (style != 0)
                {
                    excelCell.StyleIndex = (uint)style;
                }

                // Save the workbook/worksheet.
                wsPart.Worksheet.Save();
                excelFile.WorkbookPart.Workbook.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wsPart"></param>
        /// <param name="columnName"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private static Cell InsertCellIntoWorksheet(WorksheetPart wsPart, string columnName, uint rowIndex)
        {
            // Get row
            Row excelRow = InsertRowIntoWorksheet(wsPart, rowIndex);

            // Each cell has a CellReference that is essentially its index.
            string cRefernce = columnName + rowIndex;

            // Check if cell exists in the row.
            if (excelRow.Elements<Cell>().Where(c => c.CellReference == cRefernce).Count() > 0)
            {
                return excelRow.Elements<Cell>().Where(c => c.CellReference == cRefernce).First();
            }
            else // if not, create the cell.
            {
                // Cells must be in sequential order, so first determine where to insert.
                Cell refCell = null;
                foreach (Cell c in excelRow.Elements<Cell>())
                {
                    if (string.Compare(c.CellReference.Value, cRefernce, true) > 0)
                    {
                        refCell = c;
                        break;
                    }
                }

                // Insert based on refCell in order to keep cells sequential.
                Cell insertedCell = new Cell() { CellReference = cRefernce };
                excelRow.InsertBefore(insertedCell, refCell);
                wsPart.Worksheet.Save();

                return insertedCell;
            }
        }

        /// <summary>
        /// Inserts 
        /// </summary>
        /// <param name="wsPart"></param>
        /// <param name="startingColumnName"></param>
        /// <param name="startingRowIndex"></param>
        /// <returns></returns>
        private static List<List<Cell>> InsertBlockOfCellsIntoWorksheetByColumns(WorksheetPart wsPart, string startingColumnName, uint startingRowIndex, int numColumns, int numRows)
        {
            // The cells by column to return
            List<List<Cell>> cellsByCol = new List<List<Cell>>();
            for (int i = 0; i < numColumns; i++)
            {
                cellsByCol.Add(new List<Cell>());
            }

            // Get row
            List<Row> excelRows = InsertRowBlockIntoWorksheet(wsPart, startingRowIndex, numRows);

            uint currentRow = startingRowIndex;
            foreach (Row excelRow in excelRows)
            {
                // Check if the row contains any data at all.
                if (excelRow.Count() == 0)
                {
                    //Create a blank set of Cells corresponding to each row in the returning columns
                    string currentCol = startingColumnName;
                    foreach (List<Cell> cellList in cellsByCol)
                    {
                        string cReference = currentCol + currentRow;
                        Cell insertedCell = new Cell() { CellReference = cReference };
                        cellList.Add(insertedCell);
                        excelRow.Append(insertedCell);
                        currentCol = GetNextColumn(currentCol);
                    }
                }
                else // Else
                {
                    string currentCol = startingColumnName;
                    foreach (List<Cell> cellList in cellsByCol)
                    {
                        string cReference = currentCol + currentRow;
                        // Check if cell exists in the row.
                        if (excelRow.Elements<Cell>().Where(c => c.CellReference == cReference).Count() > 0)
                        {
                            cellList.Add(excelRow.Elements<Cell>().Where(c => c.CellReference == cReference).First());
                        }
                        else // if not, create the cell.
                        {
                            // Cells must be in sequential order, so first determine where to insert.
                            Cell refCell = null;
                            foreach (Cell c in excelRow.Elements<Cell>())
                            {
                                if (string.Compare(c.CellReference.Value, cReference, true) > 0)
                                {
                                    refCell = c;
                                    break;
                                }
                            }

                            // Insert based on refCell in order to keep cells sequential.
                            Cell insertedCell = new Cell() { CellReference = cReference };
                            excelRow.InsertBefore(insertedCell, refCell);
                            cellList.Add(insertedCell);
                        }
                        currentCol = GetNextColumn(currentCol);
                    }
                }
                currentRow++;
            }

            wsPart.Worksheet.Save();
            return cellsByCol;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wsPart"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private static Row InsertRowIntoWorksheet(WorksheetPart wsPart, uint rowIndex)
        {
            // Get the sheetdata for the worksheet.
            SheetData sData = wsPart.Worksheet.GetFirstChild<SheetData>();
            Row excelRow;

            // Check that a row with the given row index exists, if so, return that.
            if (sData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                return sData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else // If there is no existing row, create new one.
            {
                excelRow = new Row { RowIndex = rowIndex };
                sData.Append(excelRow);

                return excelRow;
            }
        }

        /// <summary>
        /// Inserts / gets a continous block of rows.
        /// </summary>
        /// <param name="wsPart"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private static List<Row> InsertRowBlockIntoWorksheet(WorksheetPart wsPart, uint rowIndex, int numRows)
        {
            // Get the sheetdata for the worksheet.
            SheetData sData = wsPart.Worksheet.GetFirstChild<SheetData>();

            // Get all rows in that exist in the required block
            Dictionary<uint, Row> rows = new Dictionary<uint, Row>();

            foreach (Row r in sData.Elements<Row>())
            {
                if (r.RowIndex >= rowIndex && r.RowIndex < rowIndex + numRows)
                {
                    rows.Add(r.RowIndex, r);
                }
            }

            // Insert rows that don't exist
            for (uint i = rowIndex; i < rowIndex + numRows; i++)
            {
                if (!rows.ContainsKey(i))
                {
                    Row excelRow = new Row { RowIndex = i };
                    sData.Append(excelRow); // TODO: this is potentially super buggy.

                    rows.Add(i, excelRow);
                }
            }
            // Output to sorted list
            List<Row> rowList = new List<Row>();
            for (uint i = rowIndex; i < rowIndex + numRows; i++)
            {
                rowList.Add(rows[i]);
            }


            return rowList;

            //List<Row> rows = new List<Row>();

            //for (uint i = 0; i < numRows; i++)
            //{
            //    rows.Add(InsertRowIntoWorksheet(wsPart, rowIndex + i));
            //}

            //return rows;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="spreadSheetName"></param>
        /// <returns></returns>
        // Retrieves a worksheet by name.
        private static WorksheetPart GetWorkSheetPartByName(SpreadsheetDocument document, string spreadSheetName)
        {
            return (WorksheetPart)document.WorkbookPart.GetPartById(GetIdOfWorksheet( document, spreadSheetName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="spreadSheetName"></param>
        /// <returns></returns>
        // Retrieves a worksheet by name.
        private static StringValue GetIdOfWorksheet(SpreadsheetDocument document, string spreadSheetName)
        {
            foreach (Sheet s in document.WorkbookPart.Workbook.Sheets)
            {
                if (s.Name == spreadSheetName)
                {
                    return s.Id;
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        // Returns the workbook wide Shared String Table Part.
        private static SharedStringTablePart GetSharedStringTablePart(SpreadsheetDocument document)
        {
            SharedStringTablePart sstPart;
            if (document.WorkbookPart.GetPartsCountOfType<SharedStringTablePart>() > 0)
            {
                sstPart = document.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
            }
            else
            {
                sstPart = document.WorkbookPart.AddNewPart<SharedStringTablePart>();
            }

            return sstPart;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sstPart"></param>
        /// <returns></returns>
        private static int InsertTextInSharedStringTable(string text, SharedStringTablePart sstPart)
        {
            // Create a SharedStringTable in the SharedStringTablePart if it does not exist.
            if (sstPart.SharedStringTable == null)
            {
                sstPart.SharedStringTable = new SharedStringTable();
            }


            // Look for the next available index into shared string table.
            int sstIndex = 0;

            foreach (SharedStringItem item in sstPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return sstIndex;
                }

                sstIndex++;
            }

            // Append the text onto the shared string table
            sstPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            sstPart.SharedStringTable.Save();

            // Return the index of the appended text.
            return sstIndex;
        }

        /// <summary>
        /// Inserts a list of text strings into the shared string table.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sstPart"></param>
        /// <returns></returns>
        private static Dictionary<string, int> InsertListOfTextInSharedStringTable(List<string> textStrings, SharedStringTablePart sstPart)
        {
            // Create a SharedStringTable in the SharedStringTablePart if it does not exist.
            if (sstPart.SharedStringTable == null)
            {
                sstPart.SharedStringTable = new SharedStringTable();
            }

            // Get only the distinct values
            List<string> distinctStrings = textStrings.Distinct().ToList();

            // Get all preexisting strings
            Dictionary<string, int> sstrings = new Dictionary<string, int>();
            int sstIndex = 0;

            foreach (SharedStringItem item in sstPart.SharedStringTable.Elements<SharedStringItem>())
            {
                sstrings.Add(item.InnerText, sstIndex);
                sstIndex++;
            }

            // Remove the preexisting strings from new strings
            distinctStrings = distinctStrings.Except(sstrings.Keys.ToList()).ToList();

            // Append the text onto the shared string table and the string to index dictionary
            foreach (string s in distinctStrings)
            {
                sstrings.Add(s, sstIndex);

                sstPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(s)));

                sstIndex++;
            }

            sstPart.SharedStringTable.Save();

            // Return the indexes of the shared string table. 
            return sstrings;
        }

    }
}

