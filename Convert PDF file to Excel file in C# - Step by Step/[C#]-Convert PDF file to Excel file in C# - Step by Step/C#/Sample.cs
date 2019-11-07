using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"d:\Tempos\Table.pdf";
            string pathToExcel = Path.ChangeExtension(pathToPdf, ".xls");

            // Convert PDF file to Excel file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
	    	// 'true' = Convert all data to spreadsheet (tabular and even textual).
            // 'false' = Skip textual data and convert only tabular (tables) data.
            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;

            // 'true'  = Preserve original page layout.
            // 'false' = Place tables before text.
            f.ExcelOptions.PreservePageLayout = true;

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToExcel(pathToExcel);
                
                //Open a produced Excel workbook
                if (result==0)
                {
                    System.Diagnostics.Process.Start(pathToExcel);
                }
            }
        }
    }
}
