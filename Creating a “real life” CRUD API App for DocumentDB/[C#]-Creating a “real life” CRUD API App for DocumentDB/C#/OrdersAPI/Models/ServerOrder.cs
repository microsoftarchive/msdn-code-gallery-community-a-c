using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using System;


namespace OrdersAPI.Models
{
    public class ServerOrder
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public Customer customer { get; set; }
        public Item item { get; set; }
        public string OrderStatus { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime CreationDate { get; set; }
        
    }

}