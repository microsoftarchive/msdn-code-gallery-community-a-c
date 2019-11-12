using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class PdfToTxtHelper
    {
        public static void Convert()
        {
            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            PdfToTxtConverter converter = new PdfToTxtConverter();
            converter.Load(File.ReadAllBytes("sample.pdf"));

            //Set whole document text property
            StringBuilder total = new StringBuilder();

            for (int i = 0; i < converter.PageCount; i++)
            {
                //Extract each page text from PDF with original layout
                string pageText = converter.PageToText(i);
                //You can save the page text to local file, or left in memory to other use
                File.WriteAllText(i.ToString() + ".txt", pageText, Encoding.UTF8);
                //Add each page text together
                total.Append(pageText);
            }

            converter.Dispose();
        }

        public static void Search()
        {
            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            PdfToTxtConverter document = new PdfToTxtConverter();
            document.Load(File.ReadAllBytes("sample.pdf"));

            //Whether to match upper and lower case
            document.MatchCase = false;
            //Whether to match whole word only
            document.MatchWholeWord = true;

            //Search text in whole document
            List<PdfTextInfo> infos = document.SearchText("text for search");
            //Search text in first page
            //List<PdfTextInfo> infos = document.SearchText("text for search", 0);

            foreach (PdfTextInfo info in infos)
            {
                Console.WriteLine(info.Text + "-" + info.PageId + "-" + info.Rect.X + "-" + info.Rect.Y);
            }
        }
    }
}
