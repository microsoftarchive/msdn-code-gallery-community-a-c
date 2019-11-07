using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Convert Excel file to DOCX file
            ExcelToPdf x = new ExcelToPdf();
            // You may download the latest version of SDK here: 
            // www.sautinsoft.com/convert-excel-xls-to-pdf/free-download-spreadsheet-xls-excel-to-pdf-component.php
            
            // Set DOCX as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Docx;

            string excelFile = Path.GetFullPath(@"d:\Download\test.xls");
            string docxFile = Path.ChangeExtension(excelFile, ".docx"); ;

            try
            {
                x.ConvertFile(excelFile, docxFile);
                System.Diagnostics.Process.Start(docxFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }
}
