using System.Collections.Generic;

namespace SkiShopAngular2.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Style> Styles { get; set; }
    }
}
