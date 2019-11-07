using System;
using System.Data;
using System.IO;
using System.Linq;

namespace UtilityLibrary
{
    public static class DataTableExtensionMethods
    {
        public static void RemoveFromName(this DataColumnCollection pSender, string pFindText, string pReplaceWith)
        {
            foreach (DataColumn column in pSender)
            {
                column.ColumnName = column.ColumnName.Replace(pFindText, pReplaceWith);
            }
        }
        public static void ExportToCommaDelimitedTextFile(this DataTable pSender, string pFileName)
        {
            File.WriteAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pFileName), pSender.AsEnumerable()
                .Select((row) => string.Join(",", row.ItemArray)).ToArray());
        }
    }
}
