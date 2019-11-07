using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPagingAngularClient.Models
{
    public class ClubRepository
    {
        private List<Club> clubs = new List<Club>(){
            new Club{Id = 1, Name="Arsenal", City="London"},
            new Club{Id = 2, Name="Aston Villa", City="Birmingham"},
            new Club{Id = 3, Name="Burnley", City="Burnley"},
            new Club{Id = 4, Name="Chelsea", City="London"},
            new Club{Id = 5, Name="Crystal Palace", City="London"},
            new Club{Id = 6, Name="Everton", City="Liverpool"},
            new Club{Id = 7, Name="Hull", City="Hull"},
            new Club{Id = 8, Name="Leicester", City="Leicester"},
            new Club{Id = 9, Name="Liverpool", City="Liverpool"},
            new Club{Id = 10, Name="Man City", City="London"},
            new Club{Id = 11, Name="Man Utd", City="Manchester"},
            new Club{Id = 12, Name="Newcastle", City="Newcastle"},
            new Club{Id = 13, Name="QPR", City="London"},           
            new Club{Id = 14, Name="Southampton", City="Southampton"},
            new Club{Id = 15, Name="Stoke", City="Stoke"},
            new Club{Id = 16, Name="Swansea", City="Swansea"},
            new Club{Id = 17, Name="Sunderland", City="Sunderland"},
            new Club{Id = 18, Name="Tottenham", City="London"},
            new Club{Id = 19, Name="West Bromwich Albion", City="West Bromwich"},
            new Club{Id = 20, Name="West Ham", City="London"}    
        };

        public IQueryable<Club> Clubs 
        {
            get { return this.clubs.AsQueryable(); } 
        }
    }
}