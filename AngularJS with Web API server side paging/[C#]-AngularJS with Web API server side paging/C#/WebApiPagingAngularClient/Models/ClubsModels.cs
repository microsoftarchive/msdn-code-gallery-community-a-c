using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPagingAngularClient.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class ClubPage
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

    }

    public class ClubQuery
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class ClubQuery1
    {
        public string Name { get; set; }        
    }
}