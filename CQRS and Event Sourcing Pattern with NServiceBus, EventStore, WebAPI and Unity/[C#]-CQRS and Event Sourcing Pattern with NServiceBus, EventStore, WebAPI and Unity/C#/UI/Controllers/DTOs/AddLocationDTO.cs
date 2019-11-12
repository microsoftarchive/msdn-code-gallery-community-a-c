using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationTracker.Controllers.DTOs
{
    public class AddLocationDTO
    {
        public string id { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }

        public DateTime timeStamp { get; set; }

        public string description { get; set; }
    }
}