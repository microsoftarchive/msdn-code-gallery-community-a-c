using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComboBoxes.Model
{
    public class StaticData
    {
        public static List<MyCar> MyCarsStatic 
        {
            get
            {
                return new List<MyCar>()
                {
                    new MyCar { Model="Capri", Registration="HGR H56L" },
                    new MyCar { Model="Fiesta", Registration="ABC 1DEF", PartId="HGR34" },
                };
            }
        }
    }
}
