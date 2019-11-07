using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class XlsxToCsvHelper
    {
        public static void Convert()
        {
            XlsxToCsvConverter converter = new XlsxToCsvConverter();

            //Load Excel document from stream
            using (Stream stream = File.OpenRead("sample.xlsx"))
            {
                converter.Load(stream);
            }

            //Define the delimiter symbol between cells
            converter.Delimiter = ',';

            File.WriteAllText("convert.csv", converter.SaveAsString());
        }
    }
}
