using Spire.Xls;

namespace XLStoXLSM
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of Workbook class and load the file 
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\Administrator\Desktop\test.xlsx", ExcelVersion.Version97to2003);
            //Save to the XLSM format file 
            workbook.SaveToFile("result.xlsm", FileFormat.Version2007);
        }
    }
}
