using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NServiceBus;

namespace Messages.Commands
{
    /// <summary>
    /// This is what is sent on the bus in the LocationController and this can only
    /// happen if it implements BusMessage and ICommand
    /// which implements IMessage
    /// </summary>
    public class AddLocationCommand : BusMessage, ICommand
    {
        public string Id { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Description { get; set; }



    }

}