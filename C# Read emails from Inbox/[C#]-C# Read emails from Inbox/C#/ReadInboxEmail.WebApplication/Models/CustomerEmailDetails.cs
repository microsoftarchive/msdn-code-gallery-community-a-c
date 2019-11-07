using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadInboxEmail.WebApplication.Models
{
    public class CustomerEmailDetails
    {
        #region Email

        [Display(Name = "Subject")]
        public string subject { get; set; }

        [Display(Name = "Sender")]
        public string sender { get; set; }
        public string UID { get; set; }
        public int MessegeNo { get; set; }

        [Display(Name = "Send Date")]
        public DateTime sendDate { get; set; }

        [Display(Name = "Email Body")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public ICollection<AE.Net.Mail.Attachment> Attachments { get; set; }

        [Display(Name = "Add To")]
        public string EmailTypeName { get; set; }
        public Nullable<int> EmailSplitScreenKey { get; set; }

        #endregion
    }
}