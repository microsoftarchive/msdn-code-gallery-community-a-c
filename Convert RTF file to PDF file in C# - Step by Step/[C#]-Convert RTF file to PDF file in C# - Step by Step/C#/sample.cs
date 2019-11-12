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

            string rtfPath = @"d:\test.rtf";
            string pdfPath = Path.ChangeExtension(rtfPath, ".pdf");

            int i = p.RtfToPdfConvertFile(rtfPath, pdfPath);

            if (i != 0)
            {
                System.Console.WriteLine("An error occured during converting RTF to PDF!");
            }
            else
            {
                System.Diagnostics.Process.Start(pdfPath);
            }

        }
    }
}
