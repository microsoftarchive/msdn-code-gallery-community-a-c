using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class HtmlToDocxHelper
    {
        public static void Convert()
        {
            HtmlToDocxConverter converter = new HtmlToDocxConverter();
                      
            string htmlContent = File.ReadAllText("sample.html");
            converter.Load(htmlContent);

            //Convert html to Word, and save it to local file
            using (var stream = File.OpenWrite("convert.docx"))
            {
                converter.Save(stream);
            }
        }

        public static void Convert2()
        {
            HtmlToDocxConverter converter = new HtmlToDocxConverter();            

            //Define the css for the html content
            converter.DefaultStyleSheet = ".para{font-size: 24px; color: #FF0000;}";

            string htmlContent = "<p class=\"para\">Content with special style.</p><p>Content without style</p>";
            converter.Load(htmlContent);

            File.WriteAllBytes("convert.docx", converter.SaveAsBytes());
        }
    }
}
