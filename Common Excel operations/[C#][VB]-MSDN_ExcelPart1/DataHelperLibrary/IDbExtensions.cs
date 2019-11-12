using System;
using System.Data;
using System.Linq;
using System.Text;

namespace DataHelperLibrary
{
    public static class DbExtensions
    {
        /// <summary>
        /// Used to show an SQL statement with actual values for debugging or logging to a file.
        /// </summary>
        /// <param name="pCommand">Command object</param>
        /// <returns>Command object command text with parameter values</returns>
        public static string ActualCommandText(this IDbCommand pCommand, string pQualifier = "@")
        {
            var sb = new StringBuilder(pCommand.CommandText);

            IDataParameter EmptyParameterNames = (
                from T in pCommand.Parameters.Cast<IDataParameter>()
                where string.IsNullOrWhiteSpace(T.ParameterName)
                select T).FirstOrDefault();

            if (EmptyParameterNames != null)
            {
                return pCommand.CommandText;
            }

            foreach (IDataParameter p in pCommand.Parameters)
            {
                if ((p.DbType == DbType.AnsiString) || (p.DbType == DbType.AnsiStringFixedLength) || (p.DbType == DbType.Date) || (p.DbType == DbType.DateTime) || (p.DbType == DbType.DateTime2) || (p.DbType == DbType.Guid) || (p.DbType == DbType.String) || (p.DbType == DbType.StringFixedLength) || (p.DbType == DbType.Time) || (p.DbType == DbType.Xml))
                {
                    if (p.ParameterName.Substring(0, 1) == pQualifier)
                    {
                        if (p.Value == null)
                        {
                            throw new Exception($"no value given for parameter '{p.ParameterName}'");
                        }

                        sb = sb.Replace(p.ParameterName, string.Format("'{0}'", p.Value.ToString().Replace("'", "''")));

                    }
                    else
                    {
                        sb = sb.Replace(string.Concat(pQualifier, p.ParameterName), string.Format("'{0}'", p.Value.ToString().Replace("'", "''")));
                    }
                }
                else
                {
                    sb = sb.Replace(p.ParameterName, p.Value.ToString());
                }
            }

            return sb.ToString();

        }
    }
}
