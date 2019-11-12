using AE.Net.Mail;
using System;
using System.Collections.Generic;

namespace ReadInboxEmail.WebApplication.Models
{
    public class MailMessege
    {
        public string subject { get; set; }
        public string sender { get; set; }
        public string UID { get; set; }
        public int MessegeNo { get; set; }
        public DateTime sendDate { get; set; }

        public string Body { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}