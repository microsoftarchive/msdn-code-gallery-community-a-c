using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"d:\Download\Table.pdf";
            string pathToXml = Path.ChangeExtension(pathToPdf, ".xml");

            // Convert PDF file to XML file.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            	    	
            f.XmlOptions.ConvertNonTabularDataToSpreadsheet = true;

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToXml(pathToXml);
                
                //Show HTML document in browser
                if (result==0)
                {
                    System.Diagnostics.Process.Start(pathToXml);
                }
            }
        }
    }
}
