using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class CsvToXlsxHelper
    {
        public static void Convert()
        {
            CsvToXlsxConverter converter = new CsvToXlsxConverter();

            //Define the delimiter symbol between data unit
            converter.Delimiter = '\t';

            converter.Load(File.ReadAllText("sample.csv"));            
            
            File.WriteAllBytes("convert.xlsx", converter.SaveAsBytes());
        }
    }
}
