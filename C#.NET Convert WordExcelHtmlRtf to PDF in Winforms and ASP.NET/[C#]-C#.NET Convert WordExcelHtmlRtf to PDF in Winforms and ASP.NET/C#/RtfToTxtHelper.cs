using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class RtfToTxtHelper
    {
        public static void Convert()
        {
            RtfToTxtConverter converter = new RtfToTxtConverter();

            string content = File.ReadAllText("sample.rtf");
            converter.Load(content);

            //Convert rtf to txt, and save it to byte array
            File.WriteAllText("convert.txt", converter.SaveAsString());
        }
    }
}
