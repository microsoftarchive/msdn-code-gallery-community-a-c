using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkiShopAngular2.Models
{
    public class Style
    {
        public int StyleId { get; set; }

        [StringLength(6,MinimumLength = 6)]
        [RegularExpression(@"^[0-9]{6}$")]
        public string StyleNo { get; set; }
        public string StyleName { get; set; }
        public string Gender { get; set; }
        public decimal PriceCurrent { get; set; }
        public decimal PriceRegular { get; set; }
        public string ImageSmall { get; set; }
        public string ImageBig { get; set; }

        public virtual string CategoryName { get; set; }
        public virtual Category Category { get; set; }

        public virtual string BrandName { get; set; }
        public virtual Brand Brand { get; set; }

        public StockLocation StockLocation { get; set; }

        // virtural properties are majorly for lazy loading which EF Core doesn't support now
        public virtual ICollection<Sku> Skus { get; set; }

        public virtual ICollection<StyleIdealFor> StyleIdealFors { get; set; }

    }
}
