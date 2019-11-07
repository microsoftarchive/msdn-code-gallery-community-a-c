using Microsoft.SqlServer.Types;

namespace DistanceWithinCountry.Models
{
    public class Country
    {
        public string Name { get; set; }

        public SqlGeography Geom { get; set; }
    }
}
