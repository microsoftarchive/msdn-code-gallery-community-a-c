/*
 * Copyright (c) Aspose 2002-2014. All Rights Reserved.
*/
using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;
using System.Drawing;

namespace Conditional_Formatting
{
    class Program
    {
       Worksheet _sheet = null;
        static void Main(string[] args)
        {
            //Call the custom method
            Program obj = new Program();
            obj.DoTest();
        }

        //The custom DoTest method
        public void DoTest()
        {
            //Instantiate a workbook object
            Workbook book = new Workbook();
            //Create a worksheet object and get the first worksheet
            Worksheet sheet1 = book.Worksheets[0];
            //Set the first worksheet to _sheet object
            _sheet = sheet1;

            //Call different custom methods
            //These methods exhibits different conditional formatting types with their custom
            //formattings attributes for MS Excel 2007 .xlsx file format
            AddDefaultIconSet();
            AddIconSet1();
            AddIconSet2();
            AddDefaultColorScale();
            AddDataBar1();
            AddDataBar2();
            AddTimePeriod_1();
            AddTimePeriod_2();

            //AutoFit M Column in the worksheet
            _sheet.AutoFitColumn(12);

            //Specify the output file path
            string outfn = @"c:\data\Testoutput.xlsx";
            
            //Save the excel file
            book.Save(outfn, SaveFormat.Xlsx);
        }

        //This method implements the IconSet conditional formatting type.
        private void AddDefaultIconSet()
        {
            FormatConditionCollection conds = GetFormatCondition("A1:C2", Color.Yellow);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
        }
        //This method implements the ColorScale conditional formatting type.
        private void AddDefaultColorScale()
        {
            FormatConditionCollection conds = GetFormatCondition("A3:C4", Color.Pink);
            int idx = conds.AddCondition(FormatConditionType.ColorScale);
            FormatCondition cond = conds[idx];
        }

        //This method implements the IconSet conditional formatting type with 3 Arrows Colored attribute.
        private void AddIconSet1()
        {
            FormatConditionCollection conds = GetFormatCondition("M1:O2", Color.AliceBlue);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Arrows3;
            Cell c = _sheet.Cells["M1"];
            c.PutValue("Arrows3");
        }
        //This method implements the IconSet conditional formatting type with 4 Arrows Colored attribute.
        private void AddIconSet2()
        {
            FormatConditionCollection conds = GetFormatCondition("M3:O4", Color.AntiqueWhite);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Arrows4;
            Cell c = _sheet.Cells["M3"];
            c.PutValue("Arrows4");
        }

        //This method implements the TimePeriod conditional formatting type with Today attribute.
        private void AddTimePeriod_1()
        {
            FormatConditionCollection conds = GetFormatCondition("I1:K2", Color.LightSlateGray);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.Today;
            Cell c = _sheet.Cells["I1"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Today);
            c = _sheet.Cells["K2"];
            c.PutValue(DateTime.Parse("2008/07/30"));
            c.SetStyle(style);

            c = _sheet.Cells["I2"];
            c.PutValue("Today");
        }
        //This method implements the TimePeriod conditional formatting type with Last7Days attribute.
        private void AddTimePeriod_2()
        {
            FormatConditionCollection conds = GetFormatCondition("I3:K4", Color.LightSteelBlue);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.Last7Days;
            Cell c = _sheet.Cells["I3"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/07/26"));
            c = _sheet.Cells["K4"];
            c.PutValue(DateTime.Parse("2008/08/30"));
            c.SetStyle(style);

            c = _sheet.Cells["I4"];
            c.PutValue("Last7Days");
        }



        //This method implements the DataBars conditional formatting type.
        private void AddDataBar1()
        {
            FormatConditionCollection conds = GetFormatCondition("E1:G2", Color.YellowGreen);
            int idx = conds.AddCondition(FormatConditionType.DataBar);
            FormatCondition cond = conds[idx];
        }

        //This method implements the DataBars conditional formatting type with Percentile attribute.
        private void AddDataBar2()
        {
            FormatConditionCollection conds = GetFormatCondition("E3:G4", Color.LightGreen);
            int idx = conds.AddCondition(FormatConditionType.DataBar);
            FormatCondition cond = conds[idx];
            cond.DataBar.Color = Color.Orange;
            cond.DataBar.MinCfvo.Type = FormatConditionValueType.Percentile;
            cond.DataBar.MinCfvo.Value = 30.78;
            cond.DataBar.ShowValue = false;
        }

       

        //This method adds formatted conditions.
        private FormatConditionCollection GetFormatCondition(string cellAreaName, Color color)
        {
            //Adds an empty conditional formattings
            int index = _sheet.ConditionalFormattings.Add();
            //Get the formatted conditions
            FormatConditionCollection formatConditions = _sheet.ConditionalFormattings[index];
            //Get the cell area calling the custom GetCellAreaByName method
            CellArea area = GetCellAreaByName(cellAreaName);
            //Add the formatted conditions cell area.
            formatConditions.AddArea(area);
            //Call the custom FillCell method
            FillCell(cellAreaName, color);
            //Return the formatted conditions
            return formatConditions;
        }

        //This method specifies the cell shading color for the conditional formattings cellarea range.
        private void FillCell(string cellAreaName, Color color)
        {
            CellArea area = GetCellAreaByName(cellAreaName);
            int k = 0;
            for (int i = area.StartColumn; i <= area.EndColumn; i++)
            {
                for (int j = area.StartRow; j <= area.EndRow; j++)
                {
                    Cell c = _sheet.Cells[j, i];
                    if (!color.IsEmpty)
                    {
                        Style s = c.GetStyle();
                        s.ForegroundColor = color;
                        s.Pattern = BackgroundType.Solid;
                        c.SetStyle(s);
                    }
                    //Set some random values to the cells in the cellarea range
                    int value = j + i + k;
                    c.PutValue(value);
                    k++;
                }
            }

        }

        //This method specifies the CellArea range (start row, start col, end row, end col etc.)
        //for the conditional formatting
        internal static CellArea GetCellAreaByName(string s)
        {
            CellArea area = new CellArea();
            string[] strCellRange = s.Replace("$", "").Split(':');
            int column;
            CellsHelper.CellNameToIndex(strCellRange[0], out area.StartRow, out column);
            area.StartColumn = column;
            if (strCellRange.Length == 1)
            {
                area.EndRow = area.StartRow;
                area.EndColumn = area.StartColumn;
            }
            else
            {
                CellsHelper.CellNameToIndex(strCellRange[1], out area.EndRow, out column);
                area.EndColumn = column;
            }
            return area;
        }
     
       

    }
}


