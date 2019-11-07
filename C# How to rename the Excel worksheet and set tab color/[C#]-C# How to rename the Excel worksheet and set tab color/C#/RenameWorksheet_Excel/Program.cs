using System;
using Spire.Xls;
using System.Drawing;

namespace RenameWorksheet_Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a Workbook class and load an instance from files
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\Administrator\Desktop\sampletest1.xlsx");

            //Get the sheet1,sheet2 and sheet3
            Worksheet worksheet = workbook.Worksheets[0];
            Worksheet worksheet1 = workbook.Worksheets[1];
            Worksheet worksheet2 = workbook.Worksheets[2];

            //Rename the sheets
            worksheet.Name = "Rename sheet1";
            worksheet1.Name = "Rename sheet2";
            worksheet2.Name = "Rename sheet3";

            //Set the table color
            worksheet.TabColor = Color.DarkGreen;
            worksheet1.TabColor = Color.Red;
            worksheet2.TabColor = Color.Blue;

            //Save the file
            workbook.SaveToFile("Rename.xlsx", ExcelVersion.Version2010);
            System.Diagnostics.Process.Start(workbook.FileName);
        }
    }
}
