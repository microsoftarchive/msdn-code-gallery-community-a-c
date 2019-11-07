using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class HtmlToRtfHelper
    {
        public static void Convert()
        {
            HtmlToRtfConverter converter = new HtmlToRtfConverter();

            string htmlContent = File.ReadAllText("sample.html");
            converter.Load(htmlContent);

            //Convert html to rtf, and save it to file stream
            using (var stream = File.OpenWrite("convert.rtf"))
            {
                converter.Save(stream);
            }
        }
    }
}
