using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class HtmlToTxtHelper
    {
        public static void Convert()
        {
            HtmlToTxtConverter converter = new HtmlToTxtConverter();

            string htmlContent = File.ReadAllText("sample.html");
            converter.Load(htmlContent);

            File.WriteAllText("convert.txt", converter.SaveAsString());
        }
    }
}
