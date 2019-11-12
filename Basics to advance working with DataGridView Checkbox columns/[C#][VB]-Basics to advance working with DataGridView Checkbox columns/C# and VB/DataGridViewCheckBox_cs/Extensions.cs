using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CountChecked
{
    public static class Extensions
    {
        public static DataTable DataTable(this DataGridView sender)
        {
            return (DataTable)sender.DataSource;
        }

        public static List<DataRow> CheckedRows(this DataTable sender, string ColumnName)
        {
            return (
                from T in sender.AsEnumerable()
                where T.Field<bool>(ColumnName) == true
                select T).ToList();
        }

        public static int CheckedRowCount(this DataTable sender, string ColumnName)
        {
            return sender
                .AsEnumerable()
                .Where(row => row.Field<bool>(ColumnName) == true)
                .Select(row => row).Count();
        }
    }
}