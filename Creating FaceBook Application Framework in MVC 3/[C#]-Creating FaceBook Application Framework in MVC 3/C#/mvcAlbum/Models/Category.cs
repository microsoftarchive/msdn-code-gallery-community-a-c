using System;
using System.Collections.Generic;

namespace mvcAlbum.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}