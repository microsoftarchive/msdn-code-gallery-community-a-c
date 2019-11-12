using System.Data.Services.Common;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace mvcAlbum.Models
{
    [Table("Image")]
    [DataServiceKey("ImageID")] 
    public class Image
    {
        public int ImageID { get; set; }
        public int ManufactureID { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string photo { get; set; }

        public virtual Category Categorys { get; set; }

        
    }
}