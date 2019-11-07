using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

internal class Simple2
{
    /// <summary>
    /// Read cell data from a string array and return the data
    /// in a String.
    /// </summary>
    /// <param name="FileName"></param>
    /// <param name="SheetName"></param>
    /// <returns></returns>
    public string Collect(string FileName, string SheetName)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        if (System.IO.File.Exists(FileName))
        {
            bool Proceed = false;
            Excel.Application xlApp = null;
            Excel.Workbooks xlWorkBooks = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            Excel.Sheets xlWorkSheets = null;
            Excel.Range xlCells = null;

            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkBooks = xlApp.Workbooks;
            xlWorkBook = xlWorkBooks.Open(FileName);

            xlApp.Visible = false;

            xlWorkSheets = xlWorkBook.Sheets;

            for (int x = 1; x <= xlWorkSheets.Count; x++)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];

                if (xlWorkSheet.Name == SheetName)
                {
                    Proceed = true;
                    break;
                }

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet);
                xlWorkSheet = null;
            }
            if (Proceed)
            {
                string[] Cells = { "A1", "B1", "C1", "D1", "A2", "B2", "C2", "D2", "J6", "T17" };
                foreach (var cell in Cells)
                {
                    xlCells = xlWorkSheet.Range[cell];
                    sb.AppendLine(Convert.ToString(xlCells.Value));
                    ReleaseComObject(xlCells);
                }
            }

            xlWorkBook.Close();
            xlApp.UserControl = true;
            xlApp.Quit();

            ReleaseComObject(xlCells);
            ReleaseComObject(xlWorkSheets);
            ReleaseComObject(xlWorkSheet);
            ReleaseComObject(xlWorkBook);
            ReleaseComObject(xlWorkBooks);
            ReleaseComObject(xlApp);
        }
        else
        {
            MessageBox.Show("'" + FileName + "' not located. Try one of the write examples first.");
        }

        return sb.ToString();
    }

    private void ReleaseComObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception)
        {
            obj = null;
        }
    }
}