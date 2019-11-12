using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace ExcelExtensions
{
    public static class Extensions
    {

        /// <summary>
        /// Get column letter from ordinal
        /// </summary>
        /// <param name="pIndex"></param>
        /// <returns></returns>
        public static string ExcelColumnNameFromNumber(this int pIndex)
        {
            var chars = Enumerable.Range(0, 26).Select((i) => ((char)(Convert.ToInt32('A') + i)).ToString()).ToArray();

            pIndex -= 1;

            string columnName = null;
            var quotient = pIndex / 26;

            if (quotient > 0)
            {
                columnName = ExcelColumnNameFromNumber(quotient) + chars[pIndex % 26];
            }
            else
            {
                columnName = chars[pIndex % 26].ToString();
            }

            return columnName;

        }
        /// <summary>
        /// Convert excel column letter to it's ordinal position
        /// </summary>
        /// <param name="pColumnName"></param>
        /// <returns></returns>
        public static int ExcelColumnNameToNumber(this string pColumnName)
        {
            if (string.IsNullOrEmpty(pColumnName))
            {
                throw new ArgumentNullException("pColumnName");
            }

            pColumnName = pColumnName.ToUpperInvariant();

            int sum = 0;

            for (int i = 0; i < pColumnName.Length; i++)
            {
                sum *= 26;
                sum += (pColumnName[i] - 'A' + 1);
            }

            return sum;
        }
    }
}
