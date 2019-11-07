using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Xls;


namespace ExceltoHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            //load Excel file
            Workbook workbook = new Workbook();
            workbook.LoadFromFile("Book1.xlsx");

            //convert Excel to HTML
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToHtml("sample.html");

            //Preview HTML
            System.Diagnostics.Process.Start("sample.html");
        }
    }
}
