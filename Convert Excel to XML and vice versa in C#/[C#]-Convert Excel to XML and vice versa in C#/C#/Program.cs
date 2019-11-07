using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Xls;
using System.Windows.Forms;
using System.IO;

namespace XmlAndExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            // A: Xml to Excel
            Workbook workbook = new Workbook();

            //initailize worksheet
            using (FileStream fileStream = File.OpenRead(@"..\..\ReadXMLSample.Xml"))
            {
                workbook.LoadFromXml(fileStream);
            }

            //save the document
            workbook.SaveToFile(@"..\..\Sample.xls");
            System.Diagnostics.Process.Start(@"..\..\Sample.xls");

            // B: Excel to Xml
            Workbook workbook2 = new Workbook();

            //add context to Excel file
            Worksheet sheet2 = workbook2.Worksheets[0];
            sheet2.Range["C9"].Text = "Demo Text";
            sheet2.Range["C10"].Style.KnownColor = ExcelColors.Gray25Percent;
            sheet2.Range["C11"].Style.KnownColor = ExcelColors.Blue;
            sheet2.Range["C12"].Text = "demo text";

            //save to Xml
            workbook2.SaveAsXml(@"..\..\result.xml");
            System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, @"..\..\result.xml"));
        }
    }
}
