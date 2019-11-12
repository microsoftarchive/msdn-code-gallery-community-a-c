using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Xls;

namespace AddFormulas
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook workbook = new Workbook();
            Worksheet sheet = workbook.Worksheets[0];

            int currentRow = 1;
            string currentFormula = string.Empty;

            sheet.SetColumnWidth(1, 32);
            sheet.SetColumnWidth(2, 16);
            sheet.SetColumnWidth(3, 16);

            sheet.Range[currentRow++, 1].Value = "Examples of formulas :";
            sheet.Range[++currentRow, 1].Value = "Test data:";

            CellRange range = sheet.Range["A1"];
            range.Style.Font.IsBold = true;
            range.Style.FillPattern = ExcelPatternType.Solid;
            range.Style.KnownColor = ExcelColors.LightGreen1;
            range.Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Medium;

            //test data
            sheet.Range[currentRow, 2].NumberValue = 7.3;
            sheet.Range[currentRow, 3].NumberValue = 5; ;
            sheet.Range[currentRow, 4].NumberValue = 8.2;
            sheet.Range[currentRow, 5].NumberValue = 4;
            sheet.Range[currentRow, 6].NumberValue = 3;
            sheet.Range[currentRow, 7].NumberValue = 11.3;

            sheet.Range[++currentRow, 1].Value = "Formulas"; ;
            sheet.Range[currentRow, 2].Value = "Results";
            range = sheet.Range[currentRow, 1, currentRow, 2];
            //range.Value = "Formulas";
            range.Style.Font.IsBold = true;
            range.Style.KnownColor = ExcelColors.LightGreen1;
            range.Style.FillPattern = ExcelPatternType.Solid;
            range.Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Medium;
            //str.
            currentFormula = "=\"hello\"";
            sheet.Range[++currentRow, 1].Text = "=\"hello\"";
            sheet.Range[currentRow, 2].Formula = currentFormula;
            sheet.Range[currentRow, 3].Formula = "=\"" + new string(new char[] { '\u4f60', '\u597d' }) + "\"";

            //int.
            currentFormula = "=300";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow, 2].Formula = currentFormula;

            // float
            currentFormula = "=3389.639421";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow, 2].Formula = currentFormula;

            //bool.
            currentFormula = "=false";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow, 2].Formula = currentFormula;

            currentFormula = "=1+2+3+4+5-6-7+8-9";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow, 2].Formula = currentFormula;

            currentFormula = "=33*3/4-2+10";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow, 2].Formula = currentFormula;


            // sheet reference
            currentFormula = "=Sheet1!$B$3";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow, 2].Formula = currentFormula;

            // sheet area reference
            currentFormula = "=AVERAGE(Sheet1!$D$3:G$3)";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow, 2].Formula = currentFormula;

            // Functions
            currentFormula = "=Count(3,5,8,10,2,34)";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow, 2].Formula = currentFormula;


            currentFormula = "=NOW()";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow, 2].Formula = currentFormula;
            sheet.Range[currentRow, 2].Style.NumberFormat = "yyyy-MM-DD";

            currentFormula = "=SECOND(11)";
            sheet.Range[++currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=MINUTE(12)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=MONTH(9)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=DAY(10)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=TIME(4,5,7)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=DATE(6,4,2)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=RAND()";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=HOUR(12)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=MOD(5,3)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=WEEKDAY(3)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=YEAR(23)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=NOT(true)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=OR(true)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=AND(TRUE)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=VALUE(30)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=LEN(\"world\")";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=MID(\"world\",4,2)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=ROUND(7,3)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=SIGN(4)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=INT(200)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=ABS(-1.21)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=LN(15)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=EXP(20)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=SQRT(40)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=PI()";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=COS(9)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=SIN(45)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=MAX(10,30)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=MIN(5,7)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=AVERAGE(12,45)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=SUM(18,29)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=IF(4,2,2)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;

            currentFormula = "=SUBTOTAL(3,Sheet1!B2:E3)";
            sheet.Range[currentRow, 1].Text = currentFormula;
            sheet.Range[currentRow++, 2].Formula = currentFormula;
            workbook.SaveToFile(@"..\..\Sample.xls");
        }
    }
}
