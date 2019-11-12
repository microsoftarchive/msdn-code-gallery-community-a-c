using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class HtmlToPdfHelper
    {
        public static void Convert()
        {
            HtmlToPdfConverter converter = new HtmlToPdfConverter();

            //Load html from stream
            using (Stream stream = File.OpenRead("sample.html"))
            {
                converter.Load(stream);
            }

            //Choose pdf compliance level, PDF or PDF/A
            converter.PdfStandard = PdfStandard.Pdf;

            //Convert html to pdf, and save it to file stream
            using (var stream = File.OpenWrite("convert.pdf"))
            {
                converter.Save(stream);
            }
        }

        public static void Convert2()
        {
            HtmlToPdfConverter converter = new HtmlToPdfConverter();

            //Define the css for the html content
            converter.DefaultStyleSheet = ".para{font-size: 24px; color: #FF0000;}";

            string htmlContent = "<p class=\"para\">Content with special style.</p><p>Content without style</p>";
            converter.Load(htmlContent);

            //Choose pdf compliance level, PDF or PDF/A
            converter.PdfStandard = PdfStandard.Pdf;

            File.WriteAllBytes("convert.pdf", converter.SaveAsBytes());

        }
    }
}
