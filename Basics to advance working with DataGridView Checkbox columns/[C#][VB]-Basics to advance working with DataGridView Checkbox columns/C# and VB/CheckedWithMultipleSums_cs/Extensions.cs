using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CheckedWithMultipleSums
{
    public static class Extensions
    {
        public static List<DataRow> GetRowsChecked(this DataGridView sender, string columnName)
        {
            return ((DataTable)sender
                .DataSource)
                .AsEnumerable()
                .Where((row) => row.Field<bool>(columnName)).ToList();
        }
        public static DataTable DataTable(this DataGridView sender)
        {
            return ((DataTable)sender.DataSource);
        }
    }
}
