using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataV4Sample.Models
{
    /// <summary>
    /// Ageアクションの引数
    /// </summary>
    public class AgeParameter
    {
        public int Skip { get; set; }
        public int Top { get; set; }
        public int Age { get; set; }
    }
}