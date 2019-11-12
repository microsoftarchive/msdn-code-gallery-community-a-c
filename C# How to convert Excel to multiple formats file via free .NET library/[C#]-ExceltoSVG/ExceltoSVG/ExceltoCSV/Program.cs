using Spire.Xls;
using System.Text;

namespace ExceltoCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of Workbook class and load the excel file
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\Administrator\Desktop\test.xlsx");
            //Get the first sheet and save to csv format file 
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToFile("sample.csv", " ", Encoding.UTF8);

        }
    }
}
