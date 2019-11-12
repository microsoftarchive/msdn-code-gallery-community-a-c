using System;
using System.Collections.Generic;

namespace BLAZORASPCORE.Shared.Models
{
    public partial class StudentMasters
    {
        public int StdId { get; set; }
        public string StdName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
