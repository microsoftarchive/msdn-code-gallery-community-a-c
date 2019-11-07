using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointMvc.Models
{
    public class Discussion
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        [DisplayName("Question")]
        public bool IsQuestion { get; set; }

        public Category Category { get; set; }
    }
}
