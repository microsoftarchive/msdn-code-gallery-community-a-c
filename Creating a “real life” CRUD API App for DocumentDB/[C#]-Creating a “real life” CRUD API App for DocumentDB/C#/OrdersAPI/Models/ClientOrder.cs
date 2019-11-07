using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using System;


namespace OrdersAPI.Models
{
    public class ClientOrder
    {        
        public Customer customer { get; set; }
        public Item item { get; set; }        
    }

}