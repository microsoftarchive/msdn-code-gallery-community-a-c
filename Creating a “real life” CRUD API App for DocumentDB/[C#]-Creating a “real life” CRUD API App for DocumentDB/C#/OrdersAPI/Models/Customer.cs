using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdersAPI.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }        
    }

}