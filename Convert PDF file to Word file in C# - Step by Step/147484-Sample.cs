using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"d:\simple text.pdf";
            string pathToWord = @"d:\result.doc";

            //Convert PDF file to Word file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	
            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToWord(pathToWord);
                
                //Show Word document
                if (result==0)
                {
                    System.Diagnostics.Process.Start(pathToWord);
                }
            }
        }
    }
}
