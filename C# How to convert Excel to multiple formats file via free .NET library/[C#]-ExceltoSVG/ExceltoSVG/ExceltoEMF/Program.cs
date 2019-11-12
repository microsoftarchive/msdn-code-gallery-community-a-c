using Spire.Xls;

namespace ExceltoEMF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of Workbook class and load excel file from system
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\Administrator\Desktop\test.xlsx");
            //Get the first worksheet and save to EMF format file
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToEMFImage("result.emf", 1, 1, 19, 6, System.Drawing.Imaging.EmfType.EmfPlusDual);
        }
    }
}
