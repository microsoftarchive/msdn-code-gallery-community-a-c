using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Doc;
using Spire.Doc.Documents;

namespace ConvertDoc2XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create word document
            Document document = new Document();
            document.LoadFromFile("Sample.doc");

            //Save doc file.
            document.SaveToFile("Sample.xml", FileFormat.Xml);

            //Launching the MS Word file.
            WordDocViewer("Sample.xml");
        }
        static void WordDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
