using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class DocxToTxtHelper
    {
        public static void Convert()
        {
            DocxToTxtConverter converter = new DocxToTxtConverter();

            //Load Word document from stream
            using (Stream stream = File.OpenRead("sample.docx"))
            {
                converter.Load(stream);
            }

            //Convert Word to txt, and save it to hard disk
            File.WriteAllText("convert.txt", converter.SaveAsString());
        }

        public static void Replace()
        {
            DocxToTxtConverter document = new DocxToTxtConverter();

            //Load Word document from stream
            using (Stream stream = File.OpenRead("sample.docx"))
            {
                document.Load(stream);
            }

            //Indicates whether the casing should be matched
            document.MatchCase = true;
            //Indicates whether only whole words should be matched
            document.MatchWholeWord = true;

            //Replace target text in whole document
            document.ReplaceText("old text", "new text");

            using (Stream stream = File.OpenWrite("ReplaceText.docx"))
            {
                document.SaveAfterReplace(stream);
            }
        }

        public static void Highlight()
        {
            DocxToTxtConverter document = new DocxToTxtConverter();

            document.Load(File.ReadAllBytes("sample.docx"));

            //Indicates whether the casing should be matched
            document.MatchCase = true;
            //Indicates whether only whole words should be matched
            document.MatchWholeWord = true;
            //Define highlight color
            document.HighlightColor = Color.Yellow;

            //Highlight target text in whole document
            document.HighlightText("select text");

            File.WriteAllBytes("HighlightText.docx", document.SaveAfterReplace());
        }
    }
}
