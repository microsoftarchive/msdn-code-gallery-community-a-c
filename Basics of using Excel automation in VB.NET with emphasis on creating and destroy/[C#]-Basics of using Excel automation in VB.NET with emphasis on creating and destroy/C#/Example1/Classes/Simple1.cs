using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

internal class Simple1
{
    private string ConnectionString(string FileName, string Header)
    {
        OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
        if (System.IO.Path.GetExtension(FileName).ToUpper() == ".XLS")
        {
            Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
            Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=1;HDR={0};", Header));
        }
        else
        {
            Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
            Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=1;HDR={0};", Header));
        }

        Builder.DataSource = FileName;

        return Builder.ConnectionString;
    }

    public void OpenExcel(string FileName, string SheetName)
    {
        bool Proceed = false;
        Excel.Application xlApp = null;
        Excel.Workbooks xlWorkBooks = null;
        Excel.Workbook xlWorkBook = null;
        Excel.Worksheet xlWorkSheet = null;
        Excel.Sheets xlWorkSheets = null;

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

        xlWorkBook.Close();
        xlApp.Quit();

        ReleaseComObject(xlWorkSheets);
        ReleaseComObject(xlWorkSheet);
        ReleaseComObject(xlWorkBook);
        ReleaseComObject(xlWorkBooks);
        ReleaseComObject(xlApp);

        if (Proceed)
        {
            MessageBox.Show("Found sheet, do your work here.");
        }
        else
        {
            MessageBox.Show("Sheet not located");
        }
    }

    public List<string> GetSheetNames(string FileName)
    {
        List<string> SheetNames = new List<string>();

        Excel.Application xlApp = null;
        Excel.Workbooks xlWorkBooks = null;
        Excel.Workbook xlWorkBook = null;
        Excel.Worksheet xlWorkSheet = null;
        Excel.Sheets xlWorkSheets = null;

        xlApp = new Excel.Application();
        xlApp.DisplayAlerts = false;
        xlWorkBooks = xlApp.Workbooks;
        xlWorkBook = xlWorkBooks.Open(FileName);

        xlApp.Visible = false;
        xlWorkSheets = xlWorkBook.Sheets;

        for (int x = 1; x <= xlWorkSheets.Count; x++)
        {
            xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];
            SheetNames.Add(xlWorkSheet.Name);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet);
            xlWorkSheet = null;
        }

        xlWorkBook.Close();
        xlApp.Quit();

        ReleaseComObject(xlWorkSheets);
        ReleaseComObject(xlWorkSheet);
        ReleaseComObject(xlWorkBook);
        ReleaseComObject(xlWorkBooks);
        ReleaseComObject(xlApp);

        return SheetNames;
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