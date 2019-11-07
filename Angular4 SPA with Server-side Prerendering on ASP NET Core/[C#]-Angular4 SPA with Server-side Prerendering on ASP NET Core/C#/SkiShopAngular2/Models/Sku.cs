using System.ComponentModel.DataAnnotations;

namespace SkiShopAngular2.Models
{
    public class Sku
    {
        public int SkuId { get; set; }

        [StringLength(8, MinimumLength = 8)]
        [RegularExpression(@"^[0-9]{8}$")]
        public string SkuNo { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual string StyleNo { get; set; }
        public virtual Style Style { get; set; }

    }
}
