using System.Collections.Generic;
using System.Linq;

namespace CascadingDDL.Models {
    public class Country {
        public string Code { get; set; }
        public string Name { get; set; }

        public static IQueryable<Country> GetCountries() {
            return new List<Country>
            {
                new Country {
                    Code = "CA",
                    Name = "Canada"
                },
                new Country{
                    Code = "US",
                    Name = "United States"
                },
                new Country{
                    Code = "UK",
                    Name = "United Kingdom"
                }
                // ,new Country{    // verify check for ' works
                //    Code = "CD'",
                //    Name = "Côte D'ivoire"
                //}
            }.AsQueryable();
        }
    }
}