using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages
{

    public class BusMessage
    {
        public Guid MessageId { get; set; }
        public Guid TransactionId { get; set; }
    }
}