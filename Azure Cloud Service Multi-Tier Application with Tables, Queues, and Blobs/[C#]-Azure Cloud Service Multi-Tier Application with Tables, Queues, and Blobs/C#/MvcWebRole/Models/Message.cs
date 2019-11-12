using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace MvcWebRole.Models
{
    public class Message : TableEntity
    {
        private DateTime? _scheduledDate;
        private long _messageRef;

        public Message()
        {
            this.MessageRef = DateTime.Now.Ticks;
            this.Status = "Pending";
        }

        [Required]
        [Display(Name = "Scheduled Date")]
        // DataType.Date shows Date only (not time) and allows easy hook-up of jQuery DatePicker
        [DataType(DataType.Date)]
        public DateTime? ScheduledDate 
        {
            get
            {
                return _scheduledDate;
            }
            set
            {
                _scheduledDate = value;
                this.PartitionKey = value.Value.ToString("yyyy-MM-dd");
            }
        }
        
        public long MessageRef 
        {
            get
            {
                return _messageRef;
            }
            set
            {
                _messageRef = value;
                this.RowKey = "message" + value.ToString();
            }
        }

        [Required]
        [Display(Name = "List Name")]
        public string ListName { get; set; }

        [Required]
        [Display(Name = "Subject Line")]
        public string SubjectLine { get; set; }

        // Pending, Queuing, Processing, Complete
        public string Status { get; set; }
    }
}
