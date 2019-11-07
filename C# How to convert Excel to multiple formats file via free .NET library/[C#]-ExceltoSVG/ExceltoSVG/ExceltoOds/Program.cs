using Spire.Xls;

namespace ExceltoOds
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of Workbook class and load excel file from system
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\Administrator\Desktop\test.xlsx");
            //Save to Ods format file
            workbook.SaveToFile("Result.ods", FileFormat.ODS);
        }
    }
}
