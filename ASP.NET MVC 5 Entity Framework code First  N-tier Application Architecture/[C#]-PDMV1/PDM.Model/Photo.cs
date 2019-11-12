using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.Model
{
    public class Photo
    {
        [Required]
        public int PhotoID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Image { get; set; }


        [Required]
        public Guid rowguid { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime ModifiedDate { get; set; }
    }
}
