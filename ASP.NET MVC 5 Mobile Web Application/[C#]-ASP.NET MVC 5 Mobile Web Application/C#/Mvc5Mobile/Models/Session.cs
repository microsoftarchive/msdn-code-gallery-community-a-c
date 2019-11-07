using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5Mobile.Models
{
    public class Session
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        public IEnumerable<string> Speakers { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Room { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public string DateText { get; set; }
        public string Url { get; set; }
    }
}