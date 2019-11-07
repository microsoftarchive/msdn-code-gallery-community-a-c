using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelOpenXmlLibrary
{
    /// <summary>
    /// Taken from
    /// https://dotscrapbook.wordpress.com/2012/03/23/openxml-spreadsheets-with-multiple-worksheets-using-net-sdk/
    /// </summary>
    public class SpreadsheetService 
    {
        public MemoryStream SpreadsheetStream { get; set; } // The stream that the spreadsheet gets returned on
        private Worksheet CurrentWorkSheet
        {
            get
            {
                return _spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet;
            }
        }
        private SpreadsheetDocument _spreadSheet;
        private Columns _cols;

        /// <summary>
        /// Create a basic spreadsheet template 
        /// The structure of OpenXML spreadsheet is something like this from what I can tell:
        ///                        Spreadsheet
        ///                              |         
        ///                         WorkbookPart    
        ///                   /         |             \
        ///           Workbook WorkbookStylesPart WorksheetPart
        ///                 |          |               |
        ///            Sheets     StyleSheet        Worksheet
        ///                |                        /        \       
        ///          (refers to               SheetData        Columns  
        ///           Worksheetparts)            |   
        ///                                     Rows 
        /// 
        /// Obviously this only covers the bits in this class!
        /// </summary>
        /// <returns></returns>
        public bool CreateSpreadsheet()
        {
            try
            {
                SpreadsheetStream = new MemoryStream();

                // Create the spreadsheet on the MemoryStream
                _spreadSheet = SpreadsheetDocument.Create(SpreadsheetStream, SpreadsheetDocumentType.Workbook);

                WorkbookPart wbp = _spreadSheet.AddWorkbookPart();   // Add workbook part
                //WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>(); // Add worksheet part
                Workbook wb = new Workbook(); // Workbook
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Excel xml demo";
                Worksheet ws = new Worksheet(); // Worksheet
                SheetData sd = new SheetData(); // Data on worksheet

                // Add stylesheet
                WorkbookStylesPart stylesPart = _spreadSheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                ws.Append(sd); // Add sheet data to worksheet

                _spreadSheet.WorkbookPart.Workbook = wb;
                _spreadSheet.WorkbookPart.Workbook.Save();

            }
            catch
            {
                return false;
            }

            return true;
        }

        public string AddSheet(string pName)
        {
            WorksheetPart wsp = _spreadSheet.WorkbookPart.AddNewPart<WorksheetPart>();
            wsp.Worksheet = new Worksheet();

            wsp.Worksheet.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.SheetData());

            wsp.Worksheet.Save();

            UInt32 sheetId;

            // If this is the first sheet, the ID will be 1. If this is not the first sheet, we calculate the ID based on the number of existing
            // sheets + 1.
            if (_spreadSheet.WorkbookPart.Workbook.Sheets == null)
            {
                _spreadSheet.WorkbookPart.Workbook.AppendChild(new Sheets());
                sheetId = 1;
            }
            else
            {
                sheetId = Convert.ToUInt32(_spreadSheet.WorkbookPart.Workbook.Sheets.Count() + 1);
            }

            // Create the new sheet and add it to the workbookpart
            _spreadSheet.WorkbookPart.Workbook.GetFirstChild<Sheets>().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheet()
            {
                Id = _spreadSheet.WorkbookPart.GetIdOfPart(wsp),
                SheetId = sheetId,
                Name = pName
            }
            );

            _cols = new Columns(); // Created to allow bespoke width columns
            // Save our changes
            _spreadSheet.WorkbookPart.Workbook.Save();

            return _spreadSheet.WorkbookPart.GetIdOfPart(wsp);// wsp;
        }

        private Worksheet _getWorkSheet(string pSheetId)
        {
            WorksheetPart wsp = (WorksheetPart)_spreadSheet.WorkbookPart.GetPartById(pSheetId);
            return wsp.Worksheet;
        }

        /// <summary>
        /// add the bespoke columns for the list spreadsheet
        /// </summary>
        public void CreateColumnWidth(string pSheetId, uint pStartIndex, uint pEndIndex, double pWidth)
        {
            // Find the columns in the worksheet and remove them all
            if (_getWorkSheet(pSheetId).Where(x => x.LocalName == "cols").Count() > 0)
                _getWorkSheet(pSheetId).RemoveChild<Columns>(_cols);

            // Create the column
            Column column = new Column();
            column.Min = pStartIndex;
            column.Max = pEndIndex;
            column.Width = pWidth;
            column.CustomWidth = true;
            _cols.Append(column); // Add it to the list of columns

            // Make sure that the column info is inserted *before* the sheetdata

            _getWorkSheet(pSheetId).InsertBefore<Columns>(_cols, _getWorkSheet(pSheetId).Where(x => x.LocalName == "sheetData").First());
            _getWorkSheet(pSheetId).Save();
            _spreadSheet.WorkbookPart.Workbook.Save();

        }

        /// <summary>
        /// Close the spreadsheet
        /// </summary>
        public void CloseSpreadsheet()
        {
            _spreadSheet.Close();
        }

        /// <summary>
        /// Pass a list of column headings to create the header row
        /// </summary>
        /// <param name="pHeaders"></param>
        public void AddHeader(string pSheetId, List<string> pHeaders)
        {
            // Find the sheetdata of the worksheet
            SheetData sd = (SheetData)_getWorkSheet(pSheetId).Where(x => x.LocalName == "sheetData").First();
            Row header = new Row();
            // increment the row index to the next row
            header.RowIndex = Convert.ToUInt32(sd.ChildElements.Count()) + 1;
            sd.Append(header); // Add the header row

            foreach (string heading in pHeaders)
            {
                AppendCell(header, header.RowIndex, heading, 1);

            }

            // save worksheet
            _getWorkSheet(pSheetId).Save();

        }

        /// <summary>
        /// Pass a list of data items to create a data row
        /// </summary>
        /// <param name="pDataItems"></param>
        public void AddRow(string pSheetId, List<string> pDataItems)
        {
            // Find the sheetdata of the worksheet

            SheetData sd = (SheetData)_getWorkSheet(pSheetId).Where(x => x.LocalName == "sheetData").First();
            Row header = new Row();
            // increment the row index to the next row
            header.RowIndex = Convert.ToUInt32(sd.ChildElements.Count()) + 1;


            sd.Append(header);

            foreach (string item in pDataItems)
            {
                AppendCell(header, header.RowIndex, item, 0);

            }

            // save worksheet

            _getWorkSheet(pSheetId).Save();
        }

        /// <summary>
        /// Add cell into the passed row.
        /// </summary>
        /// <param name="pRow"></param>
        /// <param name="pRowIndex"></param>
        /// <param name="pValue"></param>
        /// <param name="pStyleIndex"></param>
        private void AppendCell(Row pRow, uint pRowIndex, string pValue, uint pStyleIndex)
        {
            Cell cell = new Cell();
            cell.DataType = CellValues.InlineString;
            cell.StyleIndex = pStyleIndex;  // Style index comes from stylesheet generated in GenerateStyleSheet()
            Text t = new Text();
            t.Text = pValue;

            // Append Text to InlineString object
            InlineString inlineString = new InlineString();
            inlineString.AppendChild(t);

            // Append InlineString to Cell
            cell.AppendChild(inlineString);

            // Get the last cell's column
            string nextCol = "A";
            Cell c = (Cell)pRow.LastChild;
            if (c != null) // if there are some cells already there...
            {
                int numIndex = c.CellReference.ToString().IndexOfAny(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' });

                // Get the last column reference
                string lastCol = c.CellReference.ToString().Substring(0, numIndex);
                // Increment
                nextCol = IncrementColRef(lastCol);
            }

            cell.CellReference = nextCol + pRowIndex;

            pRow.AppendChild(cell);
        }

        // Increment the column reference in an Excel fashion, i.e. A, B, C...Z, AA, AB etc.
        // Partly stolen from somewhere on the Net and modified for my use.
        private string IncrementColRef(string lastRef)
        {
            char[] characters = lastRef.ToUpperInvariant().ToCharArray();
            int sum = 0;
            for (int i = 0; i < characters.Length; i++)
            {
                sum *= 26;
                sum += (characters[i] - 'A' + 1);
            }

            sum++;

            string columnName = String.Empty;
            int modulo;

            while (sum > 0)
            {
                modulo = (sum - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                sum = (int)((sum - modulo) / 26);
            }

            return columnName;
        }

        /// <summary>
        /// Return a stylesheet. Completely stolen from somewhere, possibly this guy's blog,
        /// although I can't find it on there:
        /// http://polymathprogrammer.com/. Thanks whoever it was, it would have been a 
        /// nightmare trying to figure this one out!
        /// </summary>
        /// <returns></returns>
        private Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(                                                               // Index 0 - The default font.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 1 - The bold font.
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 2 - The Italic font.
                        new Italic(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 2 - The Times Roman font. with 16 size
                        new FontSize() { Val = 16 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" })
                ),
                new Fills(
                    new Fill(                                                           // Index 0 - The default fill.
                        new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(                                                           // Index 1 - The default fill of gray 125 (required)
                        new PatternFill() { PatternType = PatternValues.Gray125 }),
                    new Fill(                                                           // Index 2 - The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFFFF00" } }
                        )
                        { PatternType = PatternValues.Solid })
                ),
                new Borders(
                    new Border(                                                         // Index 0 - The default border.
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                    new Border(                                                         // Index 1 - Applies a Left, Right, Top, Bottom border to a cell
                        new LeftBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new RightBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new TopBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new BottomBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },                          // Index 0 - The default cell style.  If a cell does not have a style index applied it will use this style combination instead
                    new CellFormat() { FontId = 1, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 1 - Bold 
                    new CellFormat() { FontId = 2, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 2 - Italic
                    new CellFormat() { FontId = 3, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 3 - Times Roman
                    new CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },       // Index 4 - Yellow Fill
                    new CellFormat(                                                                   // Index 5 - Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                    { FontId = 0, FillId = 0, BorderId = 0, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }      // Index 6 - Border
                )
            ); 
        }
    }
}
