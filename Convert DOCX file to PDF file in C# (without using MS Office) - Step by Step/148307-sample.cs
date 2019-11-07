using System;
using System.IO;
using System.Collections;
using SautinSoft;


namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {
            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            // You may download the latest version of SDK here:
            // http://sautinsoft.com/products/pdf-metamorphosis/download.php
            
            if (p != null)
            {
                string docxPath = @"D:\Tempos\test.docx";
                string pdfPath = Path.ChangeExtension(docxPath, ".pdf");


                // 2. Convert DOCX file to PDF file
                if (p.DocxToPdfConvertFile(docxPath, pdfPath) == 0)
                    System.Diagnostics.Process.Start(pdfPath);
                else
                {
                    System.Console.WriteLine("Conversion failed!");
                    Console.ReadLine();
                }
            }
        }
    }
}
