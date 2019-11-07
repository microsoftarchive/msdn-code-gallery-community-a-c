using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"D:\Tempos\Sample.pdf";
            string pathToText = @"D:\Tempos\Sample.txt";

            //Convert PDF file to Text file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	// You may download the latest version of SDK here:  
            // www.sautinsoft.com/products/pdf-focus/download.php  

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToText(pathToText);
                
                //Show Text document
                if (result==0)
                {
                    System.Diagnostics.Process.Start(pathToText);
                }
            }
        }
    }
}
