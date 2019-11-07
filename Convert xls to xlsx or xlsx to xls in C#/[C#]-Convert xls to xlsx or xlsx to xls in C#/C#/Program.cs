using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Xls;

namespace XlsXlsxConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // load source xls file
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"..\..\source.xls");

            // convert to xlsx file
            workbook.SaveToFile(@"..\..\temp1.xlsx", ExcelVersion.Version2010);


            // load source xlsx file
            Workbook workbook2 = new Workbook();
            workbook2.LoadFromFile(@"..\..\temp1.xlsx");

            // convert to xls file
            workbook2.SaveToFile(@"..\..\temp2.xls", ExcelVersion.Version97to2003);
            
        }
    }
}
