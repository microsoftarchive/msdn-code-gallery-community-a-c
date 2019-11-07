using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkiShopAngular2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postcode { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public decimal TotalValue { get; set; }

        public DateTime TimeCreate { get; set; } 


        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
