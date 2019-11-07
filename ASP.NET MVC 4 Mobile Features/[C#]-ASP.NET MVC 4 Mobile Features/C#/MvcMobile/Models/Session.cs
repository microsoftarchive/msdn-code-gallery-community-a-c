using System;
using System.Collections.Generic;

namespace MvcMobile.Models
{
    public class Session
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Speakers { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Room { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public string DateText { get; set; }
    }
}