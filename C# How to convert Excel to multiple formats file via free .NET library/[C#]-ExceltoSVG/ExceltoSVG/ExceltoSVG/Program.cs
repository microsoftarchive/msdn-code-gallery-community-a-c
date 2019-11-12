using System.IO;
using Spire.Xls;

namespace Excel_to_SVG
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of Workbook class and load the excel file
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\Administrator\Desktop\test.xlsx");
            /*Create a file stream, call ToSVGStream(Stream stream, int firstRow, int firstColumn, int lastRow, int lastColumn) method
            to save each worksheet of the workbook to SVG stream and then save to the file stream.*/
            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                FileStream fs = new FileStream(string.Format("E:\\Program Files\\sheet-{0}.svg", i), FileMode.Create);
                workbook.Worksheets[i].ToSVGStream(fs, 0, 0, 0, 0);
                fs.Flush();
                fs.Close();
            }
        }
    }
}