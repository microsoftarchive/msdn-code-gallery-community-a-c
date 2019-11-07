using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWS_SQS_Kinesis.Models
{
    public class MessageModel
    {
        public MessageModel() { }
        public MessageModel(string message, string url, string messageHandler)
        {
            this.Message = message;
            this.URL = url;
            this.MessageHandler = messageHandler;
        }
        public string Message { get; set; }
        public string URL { get; set; }
        public string MessageHandler { get; set; }



    }
}
