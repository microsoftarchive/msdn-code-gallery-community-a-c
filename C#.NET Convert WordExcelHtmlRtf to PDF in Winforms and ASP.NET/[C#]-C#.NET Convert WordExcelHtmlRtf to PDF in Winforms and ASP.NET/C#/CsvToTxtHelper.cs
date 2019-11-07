using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class CsvToTxtHelper
    {
        public static void Convert()
        {
            CsvToTxtConverter converter = new CsvToTxtConverter();

            converter.Load(File.ReadAllText("sample.csv"));

            File.WriteAllText("convert.txt", converter.SaveAsString());
        }
    }
}
