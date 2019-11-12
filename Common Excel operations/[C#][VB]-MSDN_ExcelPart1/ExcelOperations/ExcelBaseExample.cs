using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using ConcreteLibrary;


namespace ExcelOperations
{
    public class ExcelBaseExample : ExcelBase
    {
        /*
         * This is useful when debugging code as demo'd in the form project
         * which sends messages to a ListBox.
         */
        public EventHandler<ExaminerEventArgs> ProgressUpdated;
        private void OnProgressUpdated(string message)
        {
            ProgressUpdated?.Invoke(this, new ExaminerEventArgs(message));
        }

        public bool HasErrors { get; set; }

        public ExceptionInformation ExceptionInfo;

        public Dictionary<string, object> ReturnDictionary;

        public ExcelBaseExample()
        {
            ExceptionInfo = new ExceptionInformation()
            {
                CreatedSheet = false,
                UnKnownException = false,
                FileNotFound = false,
                SheetNotFound = false
            };
        }
        /// <summary>
        /// Get last row and column 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        /// <remarks>
        /// For a non C#7 version
        /// https://github.com/karenpayneoregon/excel-usedrowscolumns
        /// 
        /// OnProgressUpdated is used to track progress instead of setting
        /// a break-point and traversing the code. If one of the messages
        /// does not propagate to the ListBox then there is a failure point.
        /// 
        /// </remarks>
        public ExcelLast UsedRowsColumns(string fileName, string sheetName)
        {
            
            void ReleaseComObject(object pComObject)
            {
                try
                {
                    Marshal.ReleaseComObject(pComObject);
                    pComObject = null;
                }
                catch (Exception)
                {
                    pComObject = null;
                }
            }

            int rowsUsed = -1;
            int colsUsed = -1;

            if (File.Exists(fileName))
            {
                // in this case the messages to displayed in a ListBox
                OnProgressUpdated("File found");

                Excel.Application xlApp = null;
                Excel.Workbooks xlWorkBooks = null;
                Excel.Workbook xlWorkBook = null;
                Excel.Worksheet xlWorkSheet = null;
                Excel.Sheets xlWorkSheets = null;

                xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false;

                xlWorkBooks = xlApp.Workbooks;
                xlWorkBook = xlWorkBooks.Open(fileName);

                OnProgressUpdated("Opened");

                xlApp.Visible = false;

                xlWorkSheets = xlWorkBook.Sheets;

                for (int x = 1; x <= xlWorkSheets.Count; x++)
                {
                    xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];

                    if (xlWorkSheet.Name == sheetName)
                    {
                        Excel.Range xlCells = null;
                        xlCells = xlWorkSheet.Cells;

                        Excel.Range workRange = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

                        rowsUsed = workRange.Row;
                        colsUsed = workRange.Column;

                        Marshal.FinalReleaseComObject(workRange);
                        workRange = null;

                        Marshal.FinalReleaseComObject(xlCells);
                        xlCells = null;
                        OnProgressUpdated("Located sheet");
                        break;
                    }

                    Marshal.FinalReleaseComObject(xlWorkSheet);
                    xlWorkSheet = null;

                }

                
                xlWorkBook.Close();
                OnProgressUpdated("WorkBook closed");

                xlApp.UserControl = true;
                xlApp.Quit();
                OnProgressUpdated("App quitted");

                ReleaseComObject(xlWorkSheets);
                OnProgressUpdated("Released work sheets");

                ReleaseComObject(xlWorkSheet);
                OnProgressUpdated("Released work sheet");

                ReleaseComObject(xlWorkBook);
                OnProgressUpdated("Released work book");
                ReleaseComObject(xlWorkBooks);
                OnProgressUpdated("Released work books");

                ReleaseComObject(xlApp);
                OnProgressUpdated("Released app");

                return new ExcelLast() { Row = rowsUsed, Column = colsUsed };

            }
            else
            {
                /*
                 * When coding this and prior to production you could simple use
                 *
                 * OnProgressUpdated("File");
                 *
                 * When throwing this exception make sure for production there
                 * is a try-catch or a better idea is to use the BaseException class
                 * which provides properties to see if an exception has been thrown
                 * and if so inspect the exception after a method such as this
                 * one throw and exception.
                 */
                throw new Exception($"'{fileName}' not found.");
            }
        }

        /// <summary>
        /// Read specific cells from a sheet returned in a private Dictionary.
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName"></param>
        public void ReadCells(string pFileName, string pSheetName)
        {

            void ReleaseComObject(object pComObject)
            {
                try
                {
                    Marshal.ReleaseComObject(pComObject);
                    pComObject = null;
                }
                catch (Exception)
                {
                    pComObject = null;
                }
            }

            var annihilationList = new List<object>();
            var proceed = false;

            Excel.Application xlApp = null;
            Excel.Workbooks xlWorkBooks = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            Excel.Sheets xlWorkSheets = null;
            Excel.Range xlCells = null;

            xlApp = new Excel.Application();
            annihilationList.Add(xlApp);

            xlApp.DisplayAlerts = false;

            xlWorkBooks = xlApp.Workbooks;
            annihilationList.Add(xlWorkBooks);

            xlWorkBook = xlWorkBooks.Open(pFileName);
            annihilationList.Add(xlWorkBook);

            xlApp.Visible = false;

            xlWorkSheets = xlWorkBook.Sheets;
            annihilationList.Add(xlWorkSheets);

            for (var intSheet = 1; intSheet <= xlWorkSheets.Count; intSheet++)
            {
                try
                {
                    xlWorkSheet = (Excel.Worksheet)xlWorkSheets[intSheet];

                    if (xlWorkSheet.Name == pSheetName)
                    {
                        proceed = true;
                        break;
                    }
                    else
                    {
                        ReleaseComObject(xlWorkSheet);
                    }
                }
                catch (Exception ex)
                {
                    HasErrors = true;
                    ExceptionInfo.UnKnownException = true;
                    ExceptionInfo.Message = $"Error finding sheet: '{ex.Message}'";
                    ExceptionInfo.FileNotFound = false;
                    ExceptionInfo.SheetNotFound = false;

                    proceed = false;
                    annihilationList.Add(xlWorkSheet);
                }
            }


            if (!proceed)
            {
                var firstSheet = (Excel.Worksheet)xlWorkSheets[1];
                xlWorkSheet = xlWorkSheets.Add(firstSheet);
                xlWorkSheet.Name = pSheetName;

                annihilationList.Add(firstSheet);
                annihilationList.Add(xlWorkSheet);

                xlWorkSheet.Name = pSheetName;

                proceed = true;
                ExceptionInfo.CreatedSheet = true;

            }
            else
            {
                if (!annihilationList.Contains(xlWorkSheet))
                {
                    annihilationList.Add(xlWorkSheet);
                }
            }

            if (proceed)
            {

                if (!annihilationList.Contains(xlWorkSheet))
                {
                    annihilationList.Add(xlWorkSheet);
                }


                foreach (var key in ReturnDictionary.Keys.ToArray())
                {
                    try
                    {
                        xlCells = xlWorkSheet.Range[key];
                        ReturnDictionary[key] = xlCells.Value;
                        annihilationList.Add(xlCells);
                    }
                    catch (Exception e)
                    {
                        HasErrors = true;
                        ExceptionInfo.Message = $"Error reading cell [{key}]: '{e.Message}'";
                        ExceptionInfo.FileNotFound = false;
                        ExceptionInfo.SheetNotFound = false;

                        annihilationList.Add(xlCells);

                        xlWorkBook.Close();
                        xlApp.UserControl = true;
                        xlApp.Quit();

                        annihilationList.Add(xlCells);

                        return;

                    }
                }
            }
            else
            {
                /*
                 * Send information back to caller why we failed
                 */
                HasErrors = true;
                ExceptionInfo.SheetNotFound = true;
                ExceptionInfo.FileNotFound = false;
            }

            // this is debatable, should we save the file after adding a non-existing sheet?
            if (ExceptionInfo.CreatedSheet)
            {
                xlWorkSheet?.SaveAs(pFileName);
            }

            xlWorkBook.Close();
            xlApp.UserControl = true;
            xlApp.Quit();

            ReleaseObjects(annihilationList);

        }
        /// <summary>
        /// This example attempts to set pSheetName as the current/active
        /// WorkSheet in an existing Excel file.
        /// 
        /// Here we have Customers and Orders sheets
        /// 
        /// var ops = new ExcelBaseExample();
        /// var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
        /// var sheetName = "Order";
        /// 
        /// Will return false
        /// Console.WriteLine(ops.SetDefaultSheet(fileName, sheetName));
        /// 
        /// var sheetName = "Orders";
        /// 
        /// Will return true
        /// Console.WriteLine(ops.SetDefaultSheet(fileName, sheetName));        
        /// 
        /// For a real application bool is really not a proper return type,
        /// instead use an enum that reflects success and failure where
        /// failure indicates failed to set and failed to find sheet.
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName">Existing sheet to set as current</param>
        public bool SetDefaultSheet(string pFileName, string pSheetName)
        {
            bool success = false;

            /*
             * Determine if sheet exists, if not return false as there
             * is no reason to continue.
             */
            if (!GetWorkSheetNames(pFileName).Contains(pSheetName,StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            Excel.Application xlApp = null;
            Excel.Workbooks xlWorkBooks = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            Excel.Sheets xlWorkSheets = null;

            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkBooks = xlApp.Workbooks;
            xlWorkBook = xlWorkBooks.Open(pFileName);

            xlApp.Visible = false;
            xlWorkSheets = xlWorkBook.Sheets;

            for (int x = 1; x <= xlWorkSheets.Count; x++)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];

                if (xlWorkSheet.Name == pSheetName)
                {

                    ((Excel._Worksheet)xlWorkSheet).Activate();

                    xlWorkSheet.SaveAs(pFileName);
                    Marshal.FinalReleaseComObject(xlWorkSheet);
                    xlWorkSheet = null;
                    success = true;
                    break;

                }

                Marshal.FinalReleaseComObject(xlWorkSheet);
                xlWorkSheet = null;

            }

            xlWorkBook.Close();
            xlApp.UserControl = true;
            xlApp.Quit();

            ReleaseComObject(xlWorkSheets);
            ReleaseComObject(xlWorkSheet);
            ReleaseComObject(xlWorkBook);
            ReleaseComObject(xlWorkBooks);
            ReleaseComObject(xlApp);

            return success;

        }
        /// <summary>
        /// Example for exporting Excel data to a csv file. Note that in this
        /// example releasing of object differs from the other examples, the
        /// WorkBook is simply set to null and the application object Quit
        /// is called. This can give a false impression of how to release
        /// Excel objects when moving to more complex coding.
        /// </summary>
        public void ExportToDelimited_1()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = null;
            string exportFileName = null;
            xlApp.Visible = false;

            xlWorkBook = xlApp.Workbooks.Open(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "People.xlsx"));

            exportFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "People.csv");
            xlWorkBook.SaveAs(exportFileName, Excel.XlFileFormat.xlCSV);
            xlWorkBook = null;
            xlApp.Quit();
        }
        /// <summary>
        /// Same as above but in this case we release each object and note several more
        /// objects are used.
        /// </summary>
        public void ExportToDelimited_2()
        {
            void ReleaseComObject(object pComObject)
            {
                try
                {
                    Marshal.ReleaseComObject(pComObject);
                    pComObject = null;
                }
                catch (Exception)
                {
                    pComObject = null;
                }
            }

            Excel.Application xlApp = null;
            Excel.Workbooks xlWorkBooks = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;

            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;

            xlWorkBooks = xlApp.Workbooks;
            xlWorkBook = xlWorkBooks.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "People.xlsx"));

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.ActiveSheet;

            xlWorkBook.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "People.csv"),
                FileFormat: Excel.XlFileFormat.xlCSVWindows);


            xlWorkBook.Close();

            xlApp.UserControl = true;
            xlApp.Quit();

            ReleaseComObject(xlWorkSheet);
            ReleaseComObject(xlWorkBook);
            ReleaseComObject(xlWorkBooks);
            ReleaseComObject(xlApp);
        }

        private void ReleaseComObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
            }
        }

    }
}
