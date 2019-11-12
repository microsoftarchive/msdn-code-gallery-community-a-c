using System.Threading.Tasks;
using ExceptionsLibrary;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelOperations
{
    public class BadExportThatWorks : BaseExceptionsHandler
    {
        /// <summary>
        /// This works yet leads many developers in the wrong direction
        /// as code becomes more complex one or more objects may not get
        /// released but for this simply operation we are find.
        /// 
        /// Made this async as without would lock up the app until
        /// processing finished.
        /// 
        /// Note in the construction of the Application, DisplayAlerts
        /// is set to false. Without this if say the file exists there
        /// may be a prompt to overwrite it. If this operation was
        /// running unattended everything would halt until the yes/no
        /// was pressed.
        /// </summary>
        /// <param name="pDataTable"></param>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public async Task<bool> CreateSheetFromDataDataAsync(DataTable pDataTable, string pFileName)
        {
            await Task.Run(() =>
            {
                var app = new Excel.Application
                {
                    Visible = false, DisplayAlerts = false
                };

                Excel.Workbook wb = app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

                Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;

                for (var i = 1; i < pDataTable.Columns.Count; i++)
                {
                    ws.Cells[1, i] = pDataTable.Columns[i].ColumnName;
                }

                for (var i = 0; i < pDataTable.Rows.Count; i++)
                {
                    for (var j = 1; j < pDataTable.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j] = pDataTable.Rows[i][j].ToString();
                    }
                }

                wb.SaveAs(pFileName);
                wb.Close();
                app.Quit();

            }).ConfigureAwait(false);

            return true;

        }
    }
}
