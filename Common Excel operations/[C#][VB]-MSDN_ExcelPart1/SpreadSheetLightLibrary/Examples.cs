using System;
using System.Collections.Generic;
using System.Linq;
using SpreadsheetLight;

namespace SpreadSheetLightLibrary
{
    /// <summary>
    /// SpreadSheetlight provides methods to work with .xlsx files
    /// were there is no need to be concerned with disposal of 
    /// objects as done with Excel automation. In short this is a
    /// good option for many Excel operations other than OpenXml.
    /// 
    /// You could do all Excel work with this library or simply use
    /// it to assist with perhaps OleDb e.g. OleDb you can't create
    /// a new file while this library can. 
    /// 
    /// One could start with this library to learn then move to
    /// a pure OpenXml solution.
    /// 
    /// Caveats, no different from OpenXml, special care is needed
    /// for reading an writing date/time where both library have
    /// ways to work with date/time type.
    /// </summary>
    public class Examples
    {
        public int GetWorkSheetLastRow(string pFileName, string pSheetName)
        {
            var lastRow = 0;

            using (var doc = new SLDocument(pFileName, pSheetName))
            {
                /*
                 * get statistics, in this case we want the last used row so we
                 * simply index into EndRowIndex yet there are more properties.
                 */
                lastRow = doc.GetWorksheetStatistics().EndRowIndex;
            }

            return lastRow;
        }
        /// <summary>
        /// Create a new Excel file, rename the default sheet from
        /// Sheet1 to the value in pSheetName
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName"></param>
        /// <returns></returns>
        public bool CreateNewFile(string pFileName, string pSheetName)
        {
            using (var doc = new SLDocument())
            {
                doc.RenameWorksheet("Sheet1", pSheetName);
                doc.SaveAs(pFileName);
                return true;
            }

        }
        /// <summary>
        /// Create a new Excel file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public bool CreateNewFile(string pFileName)
        {
            using (var doc = new SLDocument())
            {
                doc.SaveAs(pFileName);
                return true;
            }

        }
        /// <summary>
        /// Simple example where the caller will create the Excel file if missing
        /// using the method above CreateNewFile. pTextFile is a tab delimited text
        /// file known to be validate which is imported into a specific WorkSheet.
        /// 
        /// Calling this method:
        /// var ops = new SpreadSheetLightLibrary.Examples();
        /// var excelFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SpreadSheetLight.xlsx");
        /// var textFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "import1.txt");
        /// var sheetName = "People";
        /// 
        /// if (File.Exists(excelFileName))
        /// {
        ///     File.Delete(excelFileName);
        /// }
        /// 
        /// ops.CreateNewFile(excelFileName);
        /// ops.ImportTabDelimitedTextFile(textFileName, excelFileName, sheetName);
        /// 
        /// </summary>
        /// <param name="pTextFileName"></param>
        /// <param name="pExcelFileName"></param>
        /// <param name="pSheetName"></param>
        /// <returns></returns>
        public bool ImportTabDelimitedTextFile(string pTextFileName, string pExcelFileName, string pSheetName)
        {
            try
            {
                using (SLDocument doc = new SLDocument(pExcelFileName))
                {
                    var sheets = doc.GetSheetNames(false);
                    if (sheets.Any((sheetName) => sheetName.ToLower() == pSheetName.ToLower()))
                    {
                        doc.SelectWorksheet(pSheetName);
                        doc.ClearCellContent();
                    }
                    else
                    {
                        doc.AddWorksheet(pSheetName);
                    }

                    var tio = new SLTextImportOptions();

                    doc.ImportText(pTextFileName, "A1", tio);

                    // setting column widths
                    doc.AutoFitColumn("A");
                    doc.SetColumnWidth(2, 5);

                    // do not need Sheet1
                    if (sheets.FirstOrDefault((sheetName) => sheetName.ToLower() == "sheet1") != null)
                    {
                        if (pSheetName.ToLower() != "sheet1")
                        {
                            doc.DeleteWorksheet("Sheet1");
                        }
                    }

                    doc.Save();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Example for formatting currency and dates
        /// 
        /// var ops = new SpreadSheetLightLibrary.Examples();
        /// var excelFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SpreadSheetLightFormatting.xlsx");
        /// if (File.Exists(excelFileName))
        /// {
        ///     File.Delete(excelFileName);
        /// }
        /// 
        /// ops.CreateNewFile(excelFileName);
        /// ops.SimpleFormatting(excelFileName);
        /// 
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public bool SimpleFormatting(string pFileName)
        {

            using (SLDocument doc = new SLDocument(pFileName, "Sheet1"))
            {

                SLStyle currencyStyle = doc.CreateStyle();
                currencyStyle.FormatCode = "$#,##0.000";

                doc.SetCellValue("H3", 100.3);
                doc.SetCellValue("I3", 200.5);
                doc.SetCellStyle("H3", currencyStyle);
                doc.SetCellStyle("I3", currencyStyle);

                SLStyle dateStyle = doc.CreateStyle();
                dateStyle.FormatCode = "mm-dd-yyyy";


                Dictionary<string, DateTime> dictDates = new Dictionary<string, DateTime>()
                {
                    {
                        "H4", new DateTime(2017,
                            1,
                            1)
                    },
                    {
                        "H5", new DateTime(2017,
                            1,
                            2)
                    },
                    {
                        "H6", new DateTime(2017,
                            1,
                            3)
                    },
                    {
                        "H7", new DateTime(2017,
                            1,
                            4)
                    }
                };

                foreach (var dateItem in dictDates)
                {
                    if (doc.SetCellValue(dateItem.Key, dateItem.Value))
                    {
                        doc.SetCellStyle(dateItem.Key, dateStyle);
                        doc.SetColumnWidth(dateItem.Key, 12);
                    }

                }

                doc.Save();

            }

            return true;

        }
        /// <summary>
        /// demonstrate how to get used columns in the format a a letter rather than an integer
        /// </summary>
        /// <returns></returns>
        public string[] UsedCellsInWorkSheet(string pFileName, string pSheetName) 
        {
            using (var doc = new SLDocument(pFileName, pSheetName))
            {
                SLWorksheetStatistics stats = doc.GetWorksheetStatistics();

                IEnumerable<string> columnNames = Enumerable.Range(1, stats.EndColumnIndex)
                    // ReSharper disable once ConvertClosureToMethodGroup
                    .Select((cellIndex) => SLConvert.ToColumnName(cellIndex));

                return columnNames.ToArray();
            }
        }

        /// <summary>
        /// Get sheet names in an Excel file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public List<string> SheetNames(string pFileName)
        {
            using (var doc = new SLDocument(pFileName))
            {
                return doc.GetSheetNames(false);
            }
        }

        /// <summary>
        /// Remove a sheet if it exists.
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName"></param>
        /// <returns></returns>
        public bool RemoveWorkSheet(string pFileName, string pSheetName)
        {
            using (SLDocument doc = new SLDocument(pFileName))
            {
                var workSheets = doc.GetSheetNames(false);
                if (workSheets.Any((sheetName) => sheetName.ToLower() == pSheetName.ToLower()))
                {
                    if (workSheets.Count > 1)
                    {
                        doc.SelectWorksheet(doc.GetSheetNames().FirstOrDefault((sName) => sName.ToLower() != pSheetName.ToLower()));
                    }
                    else if (workSheets.Count == 1)
                    {
                        throw new Exception("Can not delete the sole worksheet");
                    }

                    doc.DeleteWorksheet(pSheetName);
                    doc.Save();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Add a new sheet if it does not currently exists.
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName"></param>
        /// <returns></returns>
        public bool AddNewSheet(string pFileName, string pSheetName)
        {
            using (var doc = new SLDocument(pFileName))
            {
                if (!(doc.GetSheetNames(false).Any((sheetName) => sheetName.ToLower() == pSheetName.ToLower())))
                {
                    doc.AddWorksheet(pSheetName);
                    doc.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Determine if a sheet exists in the specified excel file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName"></param>
        /// <returns></returns>
        public bool SheetExists(string pFileName, string pSheetName)
        {
            using (var doc = new SLDocument(pFileName))
            {
                return doc.GetSheetNames(false).Any((sheetName) => sheetName.ToLower() == pSheetName.ToLower());
            }
        }

    }
}
