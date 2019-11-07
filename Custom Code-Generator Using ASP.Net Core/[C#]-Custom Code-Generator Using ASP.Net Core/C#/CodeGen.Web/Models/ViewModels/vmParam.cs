using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGen.Web.Models
{
    public class vmParam
    {
        public int DatabaseId { get; set; }
        public string DatabaseName { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; }
    }
}
