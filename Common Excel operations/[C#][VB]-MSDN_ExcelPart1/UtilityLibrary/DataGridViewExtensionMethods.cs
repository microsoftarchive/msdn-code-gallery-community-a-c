using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UtilityLibrary
{
    public static class DataGridViewExtensionMethods
    {
        /// <summary>
        /// Given a DataGridView populates without a data source,
        /// create a DataTable, populate from rows/cells from the
        /// DataGridView with an option to include/exclude column names.
        /// </summary>
        /// <param name="pDataGridView"></param>
        /// <param name="pColumnNames"></param>
        /// <returns></returns>
        /// <remarks>
        /// There is no attempt made to figure out data types coming
        /// from data in the DataGridView
        /// </remarks>
        public static DataTable GetDataTable(this DataGridView pDataGridView, bool pColumnNames = true)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in pDataGridView.Columns)
            {
                if (column.Visible)
                {
                    if (pColumnNames)
                    {
                        dt.Columns.Add(new DataColumn() { ColumnName = column.Name });
                    }
                    else
                    {
                        dt.Columns.Add();
                    }
                }
            }

            object[] cellValues = new object[pDataGridView.Columns.Count];

            foreach (DataGridViewRow row in pDataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        cellValues[i] = row.Cells[i].Value;
                    }
                    dt.Rows.Add(cellValues);
                }
            }

            return dt;

        }       
        /// <summary>
        /// Generates comma delimited rows into a string array.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string[] CommaDelimitedRows(this DataGridView sender)
        {
            return (
                from row in sender.Rows.Cast<DataGridViewRow>()
                where !((DataGridViewRow)row).IsNewRow
                let RowItem = string.Join(",", Array.ConvertAll(((DataGridViewRow)row).Cells.Cast<DataGridViewCell>().ToArray(), (DataGridViewCell c) => ((c.Value == null) ? "" : c.Value.ToString())))
                select RowItem).ToArray();
        }
        public static void ExportToCommandDelimitedFile(this DataGridView pSender, string pFileName)
        {
            File.WriteAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pFileName), pSender.CommaDelimitedRows());
        }

        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        /// <summary>
        /// Similar to the above but design to detect ICollection which
        /// would be from Entity Framework where a collection column was
        /// added (and need not be).
        /// </summary>
        /// <param name="sender"></param>
        public static void ExpandColumnsForEntity(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                // ensure we are not attempting to do this on a Entity
                if (col.ValueType.Name != "ICollection`1")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
    }
}
