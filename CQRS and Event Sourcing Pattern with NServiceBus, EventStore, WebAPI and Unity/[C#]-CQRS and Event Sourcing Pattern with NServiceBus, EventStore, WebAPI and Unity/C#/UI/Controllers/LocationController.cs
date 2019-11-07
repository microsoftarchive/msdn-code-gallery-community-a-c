using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LocationTracker.Controllers.DTOs;
using Messages.Commands;
using CrossCutting.Repository;

namespace LocationTracker.Controllers
{
    /// <summary>
    /// 
    /// RoutePrefix attribute is added to the Route attribute of the method
    /// /Location/api/Client and when this is POSTED from the client
    /// the JSON body is parsed to the POST method below
    /// 
    /// </summary>
    [RoutePrefix("Location")]
    public class LocationController : ApiController
    {
        /// <summary>
        /// Here we sends AddLocationCommand class as message to the NServiceBus queue
        /// AddLocation which is the endpoint defined in the Services folder
        /// AddLocation project EndPointofiguration class
        /// 
        /// Basically what happends is NServiceBus.Bost is a self hosted console
        /// app which listens for messages. Once it receives a message and de-serialises
        /// it will try and execute a class which implements 
        /// IHandlesMessages<AddLocationCommand>
        /// 
        /// See the AddLocationHandle.cs in the AddLocation project 
        /// 
        /// We can you ASP.NET SignalR to reply back to the UI on success but
        /// this is not part of this solution just now
        /// 
        /// [FromBody] attribute injectsthe JSON data from the UI client
        /// into an addLocation class instance
        /// 
        /// HttpPost attribute identifies the data ad
        /// 
        /// </summary>
        /// <param name="addLocation"></param>
        [Route("api/Client")]
        [HttpPost]
        public void Post([FromBody] AddLocationDTO addLocation)
        {
            LocationTracker.WebApiApplication.Bus.Send("AddLocation", new AddLocationCommand()
            {
                Id = addLocation.id,
                Latitude = addLocation.latitude,
                Longitude = addLocation.longitude,
                Description = addLocation.description,
                TimeStamp = addLocation.timeStamp

            });
        }
    }
}
