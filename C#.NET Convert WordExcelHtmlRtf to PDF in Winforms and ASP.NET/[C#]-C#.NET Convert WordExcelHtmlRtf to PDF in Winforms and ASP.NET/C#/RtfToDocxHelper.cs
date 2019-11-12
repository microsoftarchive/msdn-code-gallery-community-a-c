using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class RtfToDocxHelper
    {
        public static void Convert()
        {
            RtfToDocxConverter converter = new RtfToDocxConverter();

            string content = File.ReadAllText("sample.rtf");
            converter.Load(content);

            //Convert rtf to Word, and save it to byte array
            File.WriteAllBytes("convert.docx", converter.SaveAsBytes());
        }
    }
}
