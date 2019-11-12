using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PDM.Model
{
    public class ProductSubCategory
    {
        [Required]
        public int ProductSubCategoryID { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [DisplayName("Sub Category Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter valid {0}")]
        [Remote("CheckDuplicate", "ProductSubCategory", ErrorMessage = "{0} already exists")]
        public string Name { get; set; }

        [Required]
        public Guid rowguid { get; set; }

        [Required]
        public int ProductCategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<ProductCategory> ProductCategoryCollection { get; set; }

        public virtual ICollection<ProductSubCategory> ProductSubCategoryCollection { get; set; }
    }
}
