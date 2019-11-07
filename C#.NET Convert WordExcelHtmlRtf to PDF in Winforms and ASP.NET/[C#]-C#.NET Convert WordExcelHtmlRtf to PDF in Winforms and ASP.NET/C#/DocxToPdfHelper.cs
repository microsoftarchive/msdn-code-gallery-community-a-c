using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class DocxToPdfHelper
    {
        public static void Convert()
        {
            DocxToPdfConverter converter = new DocxToPdfConverter();

            //Load Word document from stream
            using (Stream stream = File.OpenRead("sample.docx"))
            {
                converter.Load(stream);
            }
            //Or load Word document form byte array
            //converter.Load(File.ReadAllBytes("sample.docx"));

            //Choose pdf compliance level, PDF or PDF/A
            converter.PdfStandard = PdfStandard.Pdf;

            //Convert Word to pdf, and save it to file stream
            using (var stream = File.OpenWrite("convert.pdf"))
            {
                converter.Save(stream);
            }
            //Or save it to byte array
            //File.WriteAllBytes("convert.pdf", converter.SaveAsBytes());
        }
    }
}
