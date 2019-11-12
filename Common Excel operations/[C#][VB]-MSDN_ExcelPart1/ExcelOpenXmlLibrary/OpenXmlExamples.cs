using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassToExcel;
using ConcreteLibrary;
using DesktopLibrary;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExceptionsLibrary;

namespace ExcelOpenXmlLibrary
{
    public class OpenXmlExamples : BaseExceptionsHandler
    {
        /// <summary>
        /// Get all Sheets in an Excel file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public Sheets GetAllWorksheets(string pFileName)
        {
            Sheets theSheets = null;

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(pFileName, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;
                theSheets = wbPart.Workbook.Sheets;
            }

            return theSheets;
        }
        /// <summary>
        /// Get all sheet names in an Excel file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public List<string> SheetNames(string pFileName)
        {
            List<string> sheetNames = new List<string>();
            var sheets = GetAllWorksheets(pFileName);
            return sheets.Select(sheet => ((Sheet)sheet).Name.Value).ToList();
        }
        /// <summary>
        /// Uses a wrapper library based on OpenXml
        /// https://github.com/madcodemonkey/ClassToExcel.OpenXml
        /// 
        /// The reason for using this library is because when using
        /// OpenXml by itself requires a great deal of code while this
        /// library requires two lines of code. It's meant for reading
        /// a worksheet whith a known structure.
        /// </summary>
        /// <param name="pFileName">Existing Excel file</param>
        /// <returns></returns>
        public List<Customer> ClassToExcelReaderServiceReader(string pFileName)
        {
            List<Customer> customers = new List<Customer>();
            var readerService = new ClassToExcelReaderService<Customer>();
            customers = readerService.ReadWorksheet(pFileName, "Customers", true);
            readerService = null;
            return customers;
        }
        /// <summary>
        /// Same as above but now we are returning a DataTable
        /// </summary>
        /// <param name="pFileName">Existing Excel file</param>
        /// <returns></returns>
        public DataTable ClassToExcelReaderServiceReaderAsDataTable(string pFileName)
        {
            var customers = new List<Customer>();
            var readerService = new ClassToExcelReaderService<Customer>();
            customers = readerService.ReadWorksheet(pFileName, "Customers", true);
            readerService = null;
            return customers.ToDataTable();
        }

        /// <summary>
        /// Create a new Excel file
        /// </summary>
        /// <param name="pFileName">Path and file name to create file</param>
        /// <param name="pSheetName">WorkSheet name</param>
        public void CreateNewFile(string pFileName, string pSheetName)
        {

            mHasException = false;

            try
            {
                using (var doc = SpreadsheetDocument.Create(pFileName, SpreadsheetDocumentType.Workbook))
                {
                    var wbp = doc.AddWorkbookPart();
                    wbp.Workbook = new Workbook();

                    var wsp = wbp.AddNewPart<WorksheetPart>();
                    wsp.Worksheet = new Worksheet(new SheetData());

                    var sheets = wbp.Workbook.AppendChild(new Sheets());

                    var sheet = new Sheet()
                    {
                        Id = wbp.GetIdOfPart(wsp),
                        SheetId = 1,
                        Name = pSheetName
                    };

                    // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                    sheets?.Append(sheet);

                    wbp.Workbook.Save();
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }
        }
        /// <summary>
        /// Create a new excel file, insert data from SQL-Server from a list.
        /// along with formating the first row which is field names
        /// </summary>
        /// <param name="pFileName">Path and file name to create</param>
        /// <param name="pSheetName">Work sheet data will be placed</param>
        /// <param name="pList">Person list</param>
        public void CreateExcelDocPopulateWithPeople(string pFileName, string pSheetName, List<Person> pList)
        {

            mHasException = false;

            try
            {
                using (var document = SpreadsheetDocument.Create(pFileName, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart wbp = document.AddWorkbookPart();
                    wbp.Workbook = new Workbook();

                    var wsp = wbp.AddNewPart<WorksheetPart>();
                    wsp.Worksheet = new Worksheet();

                    var sheets = wbp.Workbook.AppendChild(new Sheets());

                    var sheet = new Sheet()
                    {
                        Id = wbp.GetIdOfPart(wsp),
                        SheetId = 1,
                        Name = "People"
                    };

                    // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                    sheets?.Append(sheet);

                    wbp.Workbook.Save();

                    WorkbookStylesPart stylePart = wbp.AddNewPart<WorkbookStylesPart>();
                    stylePart.Stylesheet = CreateStylesheet();
                    stylePart.Stylesheet.Save();

                    var sheetData = wsp.Worksheet.AppendChild(new SheetData());

                    var headerRow = sheetData.AppendChild(new Row());
                    headerRow.AppendChild(new Cell()
                    {
                        CellValue = new CellValue("Id"),
                        DataType = CellValues.String,
                        StyleIndex = 2
                    });
                    headerRow.AppendChild(new Cell()
                    {
                        CellValue = new CellValue("First Name"),
                        DataType = CellValues.String,
                        StyleIndex = 2
                    });

                    headerRow.AppendChild(new Cell()
                    {
                        CellValue = new CellValue("Last Name"),
                        DataType = CellValues.String,
                        StyleIndex = 2
                    });

                    headerRow.AppendChild(new Cell()
                    {
                        CellValue = new CellValue("Gender"),
                        DataType = CellValues.String,
                        StyleIndex = 2
                    });

                    headerRow.AppendChild(new Cell()
                    {
                        CellValue = new CellValue("Birthday"),
                        DataType = CellValues.String,
                        StyleIndex = 2
                    });    

                    // insert people data
                    foreach (var person in pList)
                    {
                        var row = new Row();
                        
                        row.Append(
                            ConstructCell(person.Id.ToString(), CellValues.Number),
                            ConstructCell(person.FirstName, CellValues.String),
                            ConstructCell(person.LastName, CellValues.String),
                            ConstructCell(person.Role, CellValues.String),
                            ConstructCell(person.BirthDay.ToString("MM/dd/yyyy"), CellValues.String));

                        sheetData.AppendChild(row);
                    }

                    wsp.Worksheet.Save();
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }
        }
        private Stylesheet CreateStylesheet()
        {
            Stylesheet styleSheet = null;

            // 0 is default
            // 1 is header
            var fonts = new Fonts(
                new Font(new FontSize() { Val = 10 }),
                new Font(new FontSize() { Val = 12 },new Bold(),new Color() { Rgb = "FFFFFF" }));
            
            var fills = new Fills(
                new Fill(new PatternFill() { PatternType = PatternValues.None }), // Index 0 - default
                new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }), // Index 1 - default
                new Fill(new PatternFill(new ForegroundColor { Rgb = new HexBinaryValue() { Value = "000000" } })
                    { PatternType = PatternValues.Solid }) // Index 2 - header
            );

            var borders = new Borders(
                new Border(),
                new Border(
                    new LeftBorder(new Color()   { Auto = true }) { Style = BorderStyleValues.None },
                    new RightBorder(new Color()  { Auto = true }) { Style = BorderStyleValues.None },
                    new TopBorder(new Color()    { Auto = true }) { Style = BorderStyleValues.Thin },
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new DiagonalBorder())
            );

            var cellFormats = new CellFormats(
                new CellFormat(), // default
                new CellFormat { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }, // body
                new CellFormat { FontId = 1, FillId = 2, BorderId = 1, ApplyFill = true }    // header
            );

            styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);

            return styleSheet;
        }
        /// <summary>
        /// Construct cell of specific type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }

        public string UsedRange(string pFileName, string pSheetName)
        {

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(pFileName, false))
            {
                var workbookPart = spreadsheetDocument.WorkbookPart;
                var sheet = workbookPart.Workbook.Descendants<Sheet>().First(s => s.Name == pSheetName);
                var worksheetPart = workbookPart.GetPartById(sheet.Id) as WorksheetPart;
                return worksheetPart.Worksheet.SheetDimension.Reference;
            }
        }
    }
}
