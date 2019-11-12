using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PDM.Model
{
    public class Product
    {
        [Required]
        public int ProductID { get; set; }


        [Required]
        [DisplayName("Product Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression("^[a-zA-Z- ]+$", ErrorMessage = "The {0}  must in alphabets")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Product Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression("^[a-zA-Z0-9-]*$", ErrorMessage = "The {0}  must in alphanumeric")]
        public string ProductNumber { get; set; }

        [Required]
        public bool MakeFlag { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [RegularExpression("^[0-9.]*$", ErrorMessage = "The {0}  must in intergers")]
        public decimal? StandardCost { get; set; }

        [Required]
        [RegularExpression("^[0-9.]*$", ErrorMessage = "The {0}e  must in intergers")]
        public double? ListPrice { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        [RegularExpression("^[0-9.]*$", ErrorMessage = "The {0}  must in intergers")]
        public double? Weight { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime? SellStartDate { get; set; }

        [Required]
        public int ProductSubCategoryID { get; set; }

        [Required]
        public Guid rowguid { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public int ProductModelId { get; set; }
        public virtual ICollection<ProductCategory> ProductCategoryCollection { get; set; }
        public virtual ICollection<ProductSubCategory> ProductSubCategoryCollection { get; set; }

        public virtual ICollection<ProductModel> ProductModelCollection { get; set; }

        [Required]
        public int PhotoID { get; set; }

    }
}
