using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultDateTimeValue.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [StringLength(1000), Required, Index(IsUnique = true)]
        public string Title { get; set; }

        [DisplayName("Publish On")]
        [DefaultDateTimeValue("Now")]
        //[DefaultDateTimeValue("01/03/2016")]
        //[DefaultDateTimeValue("30.00:00:00")]
        //[DefaultDateTimeValue("1:00:00")]
        //[DefaultDateTimeValue("LastOfMonth")]
        public DateTime? PublishOn { get; set; }
    }
}
