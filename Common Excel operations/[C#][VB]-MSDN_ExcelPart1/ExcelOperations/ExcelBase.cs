using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ExceptionsLibrary;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelOperations
{
    public class ExcelBase : BaseExceptionsHandler
    {
        /// <summary>
        /// This works fine although on a slow computer
        /// it takes more time then using OpenXML which
        /// is used in form shown event of the main form.
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public List<string> GetWorkSheetNames(string pFileName)
        {
            var sheetNames = new List<string>();
            var annihilationList = new List<object>();

            Excel.Application xlApp = null;
            Excel.Workbooks xlWorkBooks = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            Excel.Sheets xlWorkSheets = null;

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
                    sheetNames.Add(xlWorkSheet.Name);
                    annihilationList.Add(xlWorkSheet);
                }
                catch (Exception ex)
                {
                    mHasException = true;
                    mLastException = ex;
                    
                    annihilationList.Add(xlWorkSheet);
                }
            }

            xlWorkBook.Close();
            xlApp.UserControl = true;
            xlApp.Quit();

            ReleaseObjects(annihilationList);

            return sheetNames;

        }
        /// <summary>
        /// Given a list of Excel objects, dispose of each object
        /// and while doing so check to ensure an object is not 
        /// null or nothing.
        /// </summary>
        /// <param name="pAnnihilationList"></param>
        public void ReleaseObjects(List<object> pAnnihilationList)
        {

            for (var indexer = 0; indexer < pAnnihilationList.Count; indexer++)
            {
                try
                {
                    if (pAnnihilationList[indexer] != null)
                    {
                        Marshal.ReleaseComObject(pAnnihilationList[indexer]);
                        pAnnihilationList[indexer] = null;
                    }
                }
                catch (Exception)
                {
                    pAnnihilationList[indexer] = null;
                }
            }
        }
    }
}
