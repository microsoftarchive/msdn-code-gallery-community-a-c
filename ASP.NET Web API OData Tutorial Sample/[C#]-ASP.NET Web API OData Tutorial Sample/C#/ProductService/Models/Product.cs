
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductService.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        // Navigation
        public virtual ICollection<ProductRating> Ratings { get; set; }
    }
}