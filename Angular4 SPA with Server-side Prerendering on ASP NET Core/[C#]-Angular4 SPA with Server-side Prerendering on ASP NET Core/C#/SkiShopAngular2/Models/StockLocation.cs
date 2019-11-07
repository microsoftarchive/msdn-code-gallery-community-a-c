
namespace SkiShopAngular2.Models
{
    public class StockLocation
    {
        public int StockLocationId { get; set; }
        public string Zone { get; set; }
        public string Slot { get; set; }

        public int StyleId { get; set; }
        public virtual Style Style { get; set; }
    }
}
