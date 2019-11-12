using Spire.Xls;

namespace SplitData_XLS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of Workbook class,load the excel from file and get the first worksheet of the workbook
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\Administrator\Desktop\SAMPLE.xlsx");
            Worksheet sheet = book.Worksheets[0];

            //Initialize a string and string array
            string[] splitText = null;
            string text = null;
            //Traverse from the second row to the last row
            for (int i = 1; i < sheet.LastRow; i++)
            {
                text = sheet.Range[i + 1, 1].Text;
                //Split the data by the delimited character of comma
                splitText = text.Split(',');
                //Save the data that has been split into the array and write the array items into separate columns
                for (int j = 0; j < splitText.Length; j++)
                {
                    sheet.Range[i + 1, 1 + j + 1].Text = splitText[j];
                }
            }
            //Save to file and open the result
            book.SaveToFile("result.xlsx", ExcelVersion.Version2010);
            System.Diagnostics.Process.Start("result.xlsx");
        }
    }
}
