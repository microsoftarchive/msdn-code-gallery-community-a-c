using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadInboxEmail.WebApplication.Models
{
    public class EmailConfiguration
    {
        public System.Guid ID { get; set; }
        public System.Guid PersonnelKey { get; set; }
        public string EmailAddress { get; set; }
        public string SenderName { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPPort { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public Nullable<bool> IsSMTPssl { get; set; }
        public string POPServer { get; set; }
        public string IncomingPort { get; set; }
        public string POPUsername { get; set; }
        public string POPpassword { get; set; }
        public Nullable<bool> IsPOPssl { get; set; }
        public string Fullname { get; set; }
        public string Detail { get; set; }
        public byte[] Logo { get; set; }
        public string LogoType { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.Guid> CompanyKey { get; set; }

         
    }
}