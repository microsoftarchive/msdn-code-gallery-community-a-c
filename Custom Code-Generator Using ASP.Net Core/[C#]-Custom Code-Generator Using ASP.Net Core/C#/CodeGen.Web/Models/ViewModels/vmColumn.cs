using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGen.Web.Models
{
    public class vmColumn
    {
        public int? ColumnId { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string MaxLength { get; set; }
        public string IsNullable { get; set; }
        public string TableSchema { get; set; }
        public string Tablename { get; set; }
    }
}
