using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            //Convert PDF file to Multipage TIFF file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            // You may download the latest version of SDK here: 
            // www.sautinsoft.com/products/pdf-focus/download.php 


            string pdfPath = @"d:\Tempos\table.pdf";
            string tiffPath = @"d:\Tempos\table.tiff";

            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                f.ImageOptions.Dpi = 120;
                if (f.ToMultipageTiff(tiffPath) == 0)
                {
                    System.Diagnostics.Process.Start(tiffPath);
                }
            }
        }
    }
}

