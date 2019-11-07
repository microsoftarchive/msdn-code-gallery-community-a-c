using System.Collections.Generic;

namespace ExcelOpenXmlLibrary
{
    public class SpreadsheetServiceDemo
    {
        /// <summary>
        /// Typical use in ASP.NET project
        /// </summary>
        public void Example()
        {
            var spreadsheetService = new SpreadsheetService();

            if (spreadsheetService.CreateSpreadsheet())
            {
                string oneSheet = spreadsheetService.AddSheet("Sheet1");

                spreadsheetService.CreateColumnWidth(oneSheet, 1, 1, 15);

                spreadsheetService.CreateColumnWidth(oneSheet, 2, 2, 50);

                spreadsheetService.CreateColumnWidth(oneSheet, 3, 3, 20);

                spreadsheetService.CreateColumnWidth(oneSheet, 4, 6, 20);


                spreadsheetService.AddHeader(oneSheet,
                    new List<string>()
                    {
                        "Header1",
                        "Header2",
                        "Header3",
                        "Header4",
                        "Header5",
                        "Header6"
                    });

                spreadsheetService.AddRow(oneSheet, new List<string>()
                {
                    "Data1",
                    "Data2",
                    "Data3",
                    "Data4",
                    "Data5",
                    "Data6"
                });

                var twoSheet = spreadsheetService.AddSheet("Sheet2");

                spreadsheetService.CreateColumnWidth(twoSheet, 1, 1, 15);

                spreadsheetService.CreateColumnWidth(twoSheet, 2, 2, 50);

                spreadsheetService.CreateColumnWidth(twoSheet, 3, 3, 20);

                spreadsheetService.CreateColumnWidth(twoSheet, 4, 6, 20);


                spreadsheetService.AddHeader(twoSheet,
                    new List<string>()
                    {
                        "Header1",
                        "Header2",
                        "Header3",
                        "Header4",
                        "Header5",
                        "Header6"
                    });

                spreadsheetService.AddRow(twoSheet, new List<string>()
                {
                    "Data1",
                    "Data2",
                    "Data3",
                    "Data4",
                    "Data5",
                    "Data6"
                });

                spreadsheetService.CloseSpreadsheet();

            }
        }
    }
}
