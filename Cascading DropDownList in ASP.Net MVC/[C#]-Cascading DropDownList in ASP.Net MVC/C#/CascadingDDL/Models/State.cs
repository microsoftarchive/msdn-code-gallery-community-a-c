using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascadingDDL.Models {
    public class State {
        public string Code { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
        static int cnt = 0;   // For simple demo. Normally a DBMS would use Identity.

        public static IQueryable<State> GetStates() {
            cnt = 0;
            return new List<State>
            {
                 new State
                    {
                        Code = "CA",
                        StateID=cnt++,   // using cnt++ we can insert a new element anywhere
                        StateName = "Nunavut"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "Ontario"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "Quebec"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "Nova Scotia"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "New Brunswick"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "Manitoba"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "British Columbia"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "Prince Edward Island"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "Saskatchewan"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "Alberta"
                    },
                new State
                    {
                        Code = "CA",
                        StateID=cnt++,
                        StateName = "Newfoundland and Labrador"
                    },
                new State
                    {
                        Code = "US",
                        StateID=cnt++,
                        StateName = "New-York"
                    },
                   new State
                    {
                        Code = "US",
                        StateID=cnt++,
                        StateName = "California"
                    },
                new State
                    {
                        Code = "US",
                        StateID=cnt++,
                        StateName = "Washington"
                    },
                new State
                    {
                        Code = "US",
                        StateID=cnt++,
                        StateName = "Vermont"
                    },
                    new State
                    {
                        Code = "UK",
                        StateID=cnt++,
                        StateName = "Britian"
                    },
                     new State
                    {
                        Code = "UK",
                        StateID=cnt++,
                        StateName = "Northern Ireland"
                    },
                     new State
                    {
                        Code = "UK",
                        StateID=cnt++,
                        StateName = "Scotland"
                    },
                         new State
                    {
                        Code = "UK",
                        StateID=cnt++,
                        StateName = "Wales"
                    }
            }.AsQueryable();
        }
    }
}