using System.ComponentModel.DataAnnotations;

namespace RazorPagesExample.Entity
{
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name="Product Name")]
        [StringLength(25, ErrorMessage ="Name should be 1 to 25 char in lenght")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Model")]
        [StringLength(50, ErrorMessage = "Name should be 1 to 50 char in lenght")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Price")]        
        public int Price { get; set; }
    }
}
