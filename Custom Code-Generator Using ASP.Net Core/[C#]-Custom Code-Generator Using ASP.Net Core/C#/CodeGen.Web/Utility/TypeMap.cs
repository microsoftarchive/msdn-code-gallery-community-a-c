using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGen.Web.Utility
{
    public class TypeMap
    {
        public static string GetClrType(string sqlType)
        {
            switch (sqlType)
            {
                case "Binary":
                case "binary":
                case "Image":
                case "image":
                case "Timestamp":
                case "timestamp":
                case "VarBinary":
                case "varbinary":
                    return "byte[]";

                case "Bit":
                case "bit":
                    return "bool";

                case "Char":
                case "NChar":
                case "NText":
                case "NVarChar":
                case "nvarchar":
                case "Text":
                case "text":
                case "VarChar":
                case "varchar":
                case "Xml":
                case "xml":
                    return "string";

                case "DateTime":
                case "datetime":
                case "SmallDateTime":
                case "smalldatetime":
                case "Date":
                case "date":
                case "Time":
                case "time":
                case "DateTime2":
                case "datetime2":
                    return "DateTime";

                case "Decimal":
                case "decimal":
                case "Money":
                case "money":
                case "SmallMoney":
                case "smallmoney":
                case "numeric":
                    return "decimal";

                case "Int":
                case "int":
                    return "Int32";

                case "bigint":
                case "BigInt":
                    return "long";

                case "Float":
                case "float":
                    return "double";

                case "Real":
                case "real":
                    return "float";

                case "UniqueIdentifier":
                case "uniqueidentifier":
                    return "Guid";

                case "SmallInt":
                case "smallint":
                    return "short";

                case "TinyInt":
                case "tinyint":
                    return "byte";

                case "Variant":
                case "variant":
                case "Udt":
                case "udt":
                    return "object";

                case "Structured":
                case "structured":
                    return "DataTable";

                case "DateTimeOffset":
                case "dateTimeoffset":
                    return "DateTimeOffset";

                default:
                    return "dynamic";
            }
        }
    }
}
