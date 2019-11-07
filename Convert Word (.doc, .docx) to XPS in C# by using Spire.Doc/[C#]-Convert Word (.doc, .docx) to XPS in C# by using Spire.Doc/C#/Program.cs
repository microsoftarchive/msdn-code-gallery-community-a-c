using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Doc;

namespace ConvertWordtoXPS
{
    class Program
    {
        static void Main(string[] args)
        {

            Document doc = new Document();
            doc.LoadFromFile("test.docx");
            doc.SaveToFile("toXPS.xps",FileFormat.XPS);
            System.Diagnostics.Process.Start("toXPS.xps");

        }
    }
}
