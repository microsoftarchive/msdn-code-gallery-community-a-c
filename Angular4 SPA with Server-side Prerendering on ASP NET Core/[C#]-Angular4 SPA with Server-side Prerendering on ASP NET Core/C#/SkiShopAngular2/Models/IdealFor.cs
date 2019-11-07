using System.Collections.Generic;

namespace SkiShopAngular2.Models
{
    public class IdealFor
    {
        public int IdealForId { get; set; }

        public string IdealForWhat { get; set; }

        public virtual ICollection<StyleIdealFor> StyleIdealFors { get; set; }
    }
}
