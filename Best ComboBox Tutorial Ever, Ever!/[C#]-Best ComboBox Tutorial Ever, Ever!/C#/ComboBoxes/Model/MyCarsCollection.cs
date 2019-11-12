using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComboBoxes.Model
{
    public class MyCarsCollection : List<MyCar>
    {
        public MyCarsCollection()
        {
            Add(new MyCar { Model="Fiesta", Registration="ABC 1DEF", PartId="HGR34" });
            Add(new MyCar { Model = "Capri", Registration = "HGR H56L" });
        }
    }
}
