using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"d:\Tempos\table.pdf";
            string pathToHtml = Path.ChangeExtension(pathToPdf, ".htm");

            // Convert PDF file to HTML file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            // You may download the latest version of SDK here: 
            // www.sautinsoft.com/products/pdf-focus/download.php 

            
            // Let's force the component to store images inside HTML document
            // using base-64 encoding
            f.HtmlOptions.IncludeImageInHtml = true;
            f.HtmlOptions.Title = "Simple text";

            // This property is necessary only for registered version
            

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToHtml(pathToHtml);

                //Show HTML document in browser
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(pathToHtml);
                }
            }
        }
    }
}
