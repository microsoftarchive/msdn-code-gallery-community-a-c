using OfficeOpenXml;
using OfficeOpenXml.Style;
using SampleEF6.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace SampleEF6.Report
{
    public class ReportGenerator
    {
        public static Task GenerateXLS(List<Contact> datasource, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Contacts");

                    ws.Cells[1, 1].Value = "Id";
                    ws.Cells[1, 2].Value = "Name";
                    ws.Cells[1, 3].Value = "Address";
                    ws.Cells[1, 4].Value = "City";
                    ws.Cells[1, 5].Value = "Country";

                    for (int i = 0; i < datasource.Count(); i++)
                    {
                        ws.Cells[i + 2, 1].Value = datasource.ElementAt(i).Id;
                        ws.Cells[i + 2, 2].Value = datasource.ElementAt(i).Name;
                        ws.Cells[i + 2, 3].Value = datasource.ElementAt(i).Address;
                        ws.Cells[i + 2, 4].Value = datasource.ElementAt(i).City;
                        ws.Cells[i + 2, 5].Value = datasource.ElementAt(i).Country;
                    }

                    using (ExcelRange rng = ws.Cells["A1:A5"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.DarkGray);  //Set color to DarkGray
                        rng.Style.Font.Color.SetColor(Color.Black);
                    }

                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
    }
}