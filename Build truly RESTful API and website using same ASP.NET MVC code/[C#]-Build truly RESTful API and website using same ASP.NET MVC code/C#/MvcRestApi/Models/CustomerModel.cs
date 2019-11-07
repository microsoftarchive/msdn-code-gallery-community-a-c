using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace MvcRestApi.Models
{
    [DataContract]
    public class CustomerModel
    {
        [DataMember]
        public IEnumerable<Customer> Customers { get; set; }

        public CustomerModel()
        {
            var customers = new List<Customer>();
            customers.Add(new Customer
            {
                CustomerId = "CUS0001",
                Name = "Microsoft",
                Country = "USA"
            });
            customers.Add(new Customer
            {
                CustomerId = "CUS0002",
                Name = "Google",
                Country = "USA"
            });
            customers.Add(new Customer
            {
                CustomerId = "CUS0003",
                Name = "BT",
                Country = "UK"
            });
            
            this.Customers = customers; 
        }
    }

    [DataContract(Namespace="http://omaralzabir.com")]
    public class Customer
    {
        [Required]
        [DataMember]
        public string CustomerId { get; set; }
        
        [StringLength(50), Required]
        [DataMember]
        public string Name { get; set; }
        
        [StringLength(20), Required]
        [DataMember]        
        public string Country { get; set; }

        //[DataMember]
        public IEnumerable<Order> Orders
        {
            get;
            set; 
        }

        public Customer()
        {
            var orders = new List<Order>();
            orders.Add(new Order
            {
                OrderId = "ORD00001",
                ProductName = "Chairs",
                ProductPrice = 200,
                ProductQuantity = 1000
            });
            orders.Add(new Order
            {
                OrderId = "ORD00002",
                ProductName = "Tables",
                ProductPrice = 200,
                ProductQuantity = 1000
            });
            orders.Add(new Order
            {
                OrderId = "ORD00003",
                ProductName = "Computers",
                ProductPrice = 200,
                ProductQuantity = 1000
            });

            this.Orders = orders;
        }

    }

    [DataContract]
    public class Order
    {
        [Required]
        [DataMember]
        public string OrderId { get; set; }
        
        [StringLength(255), Required]
        [DataMember]
        public string ProductName { get; set; }
        
        [DataMember]
        public int ProductQuantity { get; set; }
        
        [DataMember]
        public double ProductPrice { get; set; }
    }
}