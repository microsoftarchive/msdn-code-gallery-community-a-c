using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class XlsxToPdfHelper
    {
        public static void Convert()
        {
            XlsxToPdfConverter converter = new XlsxToPdfConverter();

            //Load Excel document from stream
            using (Stream stream = File.OpenRead("sample.xlsx"))
            {
                converter.Load(stream);            
            }
                      
            //Convert active worksheet to pdf
            converter.ContentPart = PdfContentPart.FromActiveSheet;

            //If Print Area is set in the workbook, the output pdf will only show the Print Area
            //So dislpay whole worksheet need to disable this property
            converter.DisplayAsPrintArea = false;
                       
            //Convert Excel to pdf, and save it to file stream
            using (var stream = File.OpenWrite("convert.pdf"))
            {
                converter.Save(stream);
            }
        }

        public static void Convert2()
        {
            XlsxToPdfConverter converter = new XlsxToPdfConverter();

            //Load Excel document from byte array
            converter.Load(File.ReadAllBytes("sample.xlsx"));

            //Convert selected cell ranges in active worksheet to pdf
            converter.ContentPart = PdfContentPart.FromRanges;

            //Select ranges by row and column id
            converter.SelectedRanges.Add(new Range(2, 0, 4, 1));
            converter.SelectedRanges.Add(new Range(7, 0, 12, 1));

            //Convert Excel to pdf, and save it to local file
            File.WriteAllBytes("convert.pdf", converter.SaveAsBytes());
        }
    }
}
