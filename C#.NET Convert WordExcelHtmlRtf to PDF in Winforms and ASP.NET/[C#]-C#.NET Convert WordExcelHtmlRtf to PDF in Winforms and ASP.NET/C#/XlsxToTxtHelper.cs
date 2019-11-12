using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class XlsxToTxtHelper
    {
        public static void Convert()
        {
            XlsxToTxtConverter converter = new XlsxToTxtConverter();

            //Load Excel document from stream
            using (Stream stream = File.OpenRead("sample.xlsx"))
            {
                converter.Load(stream);
            }       

            File.WriteAllText("convert.txt", converter.SaveAsString());
        }

        public static void Search()
        {
            XlsxToTxtConverter spreadsheet = new XlsxToTxtConverter();

            //Load Excel document from stream
            using (Stream stream = File.OpenRead("sample.xlsx"))
            {
                spreadsheet.Load(stream);
            }

            //Indicates whether the casing should be matched
            spreadsheet.MatchCase = true;
            //If set to true, search both in formulas and cell data value
            //If set to false, only search in cell data value
            spreadsheet.SearchInFormulas = true;

            //Search text in whole workbook
            List<ExcelTextInfo> infos = spreadsheet.SearchText("SUM");

            foreach (ExcelTextInfo info in infos)
            {
                Console.WriteLine("Find in worksheet: {0}, cell({1}, {2})", info.SheetName, info.RowIndex, info.ColumnIndex);
                Console.WriteLine("Raw value (such as Formula expression): {0}", info.RawValue);
                Console.WriteLine("Result value: {0}", info.ResultValue);
            }

            Console.ReadLine();            
        }

        public static void Replace()
        {
            XlsxToTxtConverter spreadsheet = new XlsxToTxtConverter();

            spreadsheet.Load(File.ReadAllBytes("sample.xlsx"));

            //Indicates whether the casing should be matched
            spreadsheet.MatchCase = true;
            //If set to true, search both in formulas and cell data value
            //If set to false, only search in cell data value
            spreadsheet.SearchInFormulas = false;

            //Replace all text in workbook
            spreadsheet.ReplaceText("SUM", "Test");

            File.WriteAllBytes("ReplaceText.xlsx", spreadsheet.SaveAfterReplace());
        }
    }
}
