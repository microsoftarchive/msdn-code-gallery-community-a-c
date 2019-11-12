using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DesktopLibrary
{
    public static class GenericConverters
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> pSender)
        {
            var resultTable = new DataTable();

            // column names
            PropertyInfo[] firstRecord = null;

            if (pSender == null) return resultTable;

            foreach (T rec in pSender)
            {
                if (firstRecord == null)
                {
                    firstRecord = ((Type)rec.GetType()).GetProperties();
                    foreach (var pi in firstRecord)
                    {
                        Type columnType = pi.PropertyType;

                        if ((columnType.IsGenericType) && (columnType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            columnType = columnType.GetGenericArguments()[0];
                        }

                        resultTable.Columns.Add(new DataColumn(pi.Name, columnType));
                    }
                }

                var dr = resultTable.NewRow();

                foreach (var pi in firstRecord)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
                }

                resultTable.Rows.Add(dr);
            }

            return resultTable;
        }
    }
}
