using System.Collections.Generic;

namespace SkiShopAngular2.ViewModels
{
    public class StylesByCategoryVM
    {
        public string StyleNo { get; set; }
        public string StyleName { get; set; }
        public string Gender { get; set; }
        public decimal PriceCurrent { get; set; }
        public decimal PriceRegular { get; set; }
        public string ImageSmall { get; set; }
        public string ImageBig { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }

        public List<string> IdealFors { get; set; }
    }
}
