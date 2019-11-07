using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace MvcWebRole.Models
{
    public class Subscriber : TableEntity
    {
        [Required]
        [Display(Name = "List Name")]
        public string ListName
        {
            get
            {
                return this.PartitionKey;
            }
            set
            {
                this.PartitionKey = value;
            }
        }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress
        {
            get
            {
                return this.RowKey;
            }
            set
            {
                this.RowKey = value;
            }
        }

        public string SubscriberGUID { get; set; }

        public bool? Verified { get; set; }
    }
}