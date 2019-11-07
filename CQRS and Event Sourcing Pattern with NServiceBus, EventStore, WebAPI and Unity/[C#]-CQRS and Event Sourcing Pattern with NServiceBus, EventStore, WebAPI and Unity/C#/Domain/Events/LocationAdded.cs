using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DomainBase
{
    public class LocationAdded: IDomainEvent
    {
        public string Id { get; set; }

        public double Longtitude { get; set; }

        public double Latitude { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Description { get; set; }

        public LocationAdded(string id, double latitude, double longtitude, DateTime timestamp, string description)
        {
            Id = id;
            Latitude = latitude;
            Longtitude = longtitude;
            TimeStamp = timestamp;
            Description = description;
        }

    }
}
