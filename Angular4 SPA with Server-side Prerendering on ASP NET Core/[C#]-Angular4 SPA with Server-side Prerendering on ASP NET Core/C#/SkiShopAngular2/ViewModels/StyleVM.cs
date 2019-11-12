using System.Collections.Generic;

namespace SkiShopAngular2.ViewModels
{
    public class StyleVM
    {
        public string StyleNo { get; set; }
        public string StyleName { get; set; }
        public string Gender { get; set; }
        public decimal PriceCurrent { get; set; }
        public decimal PriceRegular { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string BrandName { get; set; }
        public string ImageBig { get; set; }
        public List<string> SkuNos { get; set; }
        public List<string> Sizes { get; set; }
        public List<int> Quantities { get; set; }

    }
}
