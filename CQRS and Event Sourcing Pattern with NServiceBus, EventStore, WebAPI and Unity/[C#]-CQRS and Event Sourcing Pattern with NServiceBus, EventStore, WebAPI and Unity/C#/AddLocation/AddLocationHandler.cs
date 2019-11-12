using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.Repository;
using Domain.Aggregates;
using Messages.Commands;
using NServiceBus;
using System.Diagnostics;
using Microsoft.Practices.Unity;

/// <summary>
/// 
/// NServiceBus manages the classes that implement IHandleMessages. 
/// When the AddLocationCommand message arrives in the input queue
/// sent by the LocationController POST method using Bus.Send(..) it is deserialized, 
/// and then, based on its type NServiceBus instantiates the relevant classes and calls their Handle
/// method passing in the message object 
/// 
/// It is called because the BusConfiguration
/// 
/// </summary>
namespace AddLocation
{

    public class AddLocationHandler : IHandleMessages<AddLocationCommand>
    {

        
        public IDomainRepository domainRepository { get; set; }
       
       
        /// <summary>
        /// NServiceBus.Host receives AddLocationCommand and finds the
        /// class implementing IHandleMessages<AddLocationCommand>
        /// 
        /// It then creates an instance of this class and uses the settings
        /// in EndpointConfig.cs to inject an instance of EventSourceDomainRepository 
        /// in depositRepository property. NServiceBus proceeds to run the
        /// Handle(AddLocation message) methods parsing in the methid sent from the
        /// LocationController across the bus
        /// 
        /// In this example NServiceBus is self hosted in a command Windows
        /// and when it first loads it scans in EndpointConfig.cs if present
        /// 
        /// </summary>
        public AddLocationHandler() 
        {
             domainRepository = (IDomainRepository)UnityConfig.GetConfiguredContainer().Resolve(typeof(IDomainRepository));
        }
        
        /// <summary>
        /// This triggers when the bus receives the AddLocationCommand. 
        /// </summary>
        /// <param name="message"></param>
        public void Handle(AddLocationCommand message)
        {  
            //  We now access the aggregate (DDD speak) let's just call it an
            //  in-memory representation of the data we want to write to the event
            //  store       
            //
            var client = Location.AddLocation(message.Id, message.Latitude, message.Longitude, message.TimeStamp, message.Description);
            
            // Now we want to write the updated aggregate to the EventStore
            // 
            // the true flag is important here as it is can be used to tell the
            // EventStore repository manager to restrict operations based on
            // the fact it is a new stream or not             
                     
            domainRepository.Save<Location>(client, true);
        }
    }
}
