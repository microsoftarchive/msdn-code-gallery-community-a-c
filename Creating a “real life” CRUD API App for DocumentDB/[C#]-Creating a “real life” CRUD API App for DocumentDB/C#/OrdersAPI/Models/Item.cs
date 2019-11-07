using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdersAPI.Models
{
    public class Item
    {
        public string Category { get; set; }
        public string Brand { get; set; }
        public string ProductType { get; set; }
        public string Article { get; set; }
        public int Amount { get; set; }        
    }

}