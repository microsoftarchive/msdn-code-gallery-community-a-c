using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class RtfToPdfHelper
    {
        public static void Convert()
        {
            RtfToPdfConverter converter = new RtfToPdfConverter();

            //Load rtf document from stream
            using (Stream stream = File.OpenRead("sample.rtf"))
            {
                converter.Load(stream);
            }

            //Convert rtf to pdf, and save it to byte array
            File.WriteAllBytes("convert.pdf", converter.SaveAsBytes());
        }
    }
}
