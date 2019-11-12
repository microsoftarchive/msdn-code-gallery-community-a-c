using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {

            //Convert multipage TIFF file to PDF file
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();
            // You may download the latest version of SDK here:   
            // www.sautinsoft.com/products/convert-html-pdf-and-tiff-pdf-asp.net/download.php 

            //specify converting options
            v.PageStyle.PageSize.Auto();
             
            string tiffPath = Path.GetFullPath(@"d:\Tempos\multipages.tiff");
            string pdfPath = Path.ChangeExtension(tiffPath, ".pdf");

            //Convert image file to pdf
            int ret = v.ConvertImageFileToPDFFile(tiffPath, pdfPath);

            if (ret == 0)
            {
                //Show produced PDF in Acrobat Reader
                System.Diagnostics.Process.Start(pdfPath);
            }
        }
    }
}
