using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {
           	
            SautinSoft.HtmlToRtf h = new SautinSoft.HtmlToRtf();
            // You may download the latest version of SDK here: 
            // http://sautinsoft.com/products/html-to-rtf/download.php 

            string htmlFile = Path.Combine(@"d:\download\utf-8.html");
            string rtfFile = Path.ChangeExtension(htmlFile, ".rtf");


            // Convert HTML to RTF
            int res = h.ConvertFile(htmlFile, rtfFile);

            if (res == 0)
            {
                Console.WriteLine("Converted successfully!");
                System.Diagnostics.Process.Start(rtfFile);
            }
            else
            {
                Console.WriteLine("Converting failed!");
                Console.ReadLine();
            }
        }
    }
}
