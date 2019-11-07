using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.DomainBase;

namespace Domain.Aggregates
{
    public class Location : AggregateBase, IAggregate
    {
        public string Id { get; set; }
              
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Description { get; set; }


        public override string AggregateId
        {
            get { return Id; }
        }
        
        public Location()
        {
            RegisterTransition<LocationAdded>(Apply);
           
        }

        private void Apply(LocationAdded obj)
        {
            
            this.Id=obj.Id;
            this.Latitude = obj.Latitude;
            this.Longitude = obj.Longtitude;
            this.TimeStamp = DateTime.UtcNow;
            this.Description = obj.Description;

          
        }


        public Location(string id, double latitude, double longtitude, DateTime timestamp, string description) : this()
        {
            RaiseEvent(new LocationAdded(id, latitude, longtitude, timestamp, description));
        }

        public static Location AddLocation(string id, double latitude, double longtitude, DateTime timestamp, string description)
        {
            return new Location(id, latitude, longtitude, timestamp, description);
        }

        
    }
}
