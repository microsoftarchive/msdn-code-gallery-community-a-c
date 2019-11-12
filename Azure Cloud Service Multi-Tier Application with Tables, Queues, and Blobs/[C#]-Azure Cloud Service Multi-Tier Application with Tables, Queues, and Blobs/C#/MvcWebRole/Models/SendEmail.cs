using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace MvcWebRole.Models
{
    public class SendEmail : TableEntity
    {
        public long MessageRef { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public string SubjectLine { get; set; }
        public string ListName { get; set; }
        public String FromEmailAddress { get; set; }
        public string EmailAddress { get; set; }
        public string SubscriberGUID { get; set; }
        public bool? EmailSent { get; set; }
    }
}