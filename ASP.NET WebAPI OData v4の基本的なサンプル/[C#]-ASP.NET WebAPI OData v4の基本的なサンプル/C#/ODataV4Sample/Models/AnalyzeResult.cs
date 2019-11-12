using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataV4Sample.Models
{
    public class AnalyzeResult
    {
        public double Average { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
    }
}