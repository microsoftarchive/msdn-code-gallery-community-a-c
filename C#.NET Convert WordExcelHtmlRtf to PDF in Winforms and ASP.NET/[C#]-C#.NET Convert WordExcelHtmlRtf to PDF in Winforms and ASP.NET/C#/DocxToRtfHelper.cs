using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class DocxToRtfHelper
    {
        public static void Convert()
        {
            DocxToRtfConverter converter = new DocxToRtfConverter();

            //Load Word document from byte array           
            converter.Load(File.ReadAllBytes("sample.docx"));

            //Convert Word to rtf, and save it to hard disk
            File.WriteAllText("convert.rtf", converter.SaveAsString());
        }
    }
}
