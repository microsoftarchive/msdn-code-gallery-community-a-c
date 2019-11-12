using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using Microsoft.Practices.Unity.Configuration;
using CrossCutting.Repository;
using CrossCutting.DomainBase;
using CrossCutting;
using Newtonsoft.Json;
using EventStore.ClientAPI.SystemData;
using System.Net;
using System.Threading.Tasks;

public class EventStoreDomainRepository : DomainRepositoryBase
{
        
        private IEventStoreConnection connection;
        private const string Category = "LocationTracker";
            
        /// <summary>
        /// Set-up the connection 
        ///  
        /// Use default credentials - hard coded for now
        /// 
        /// </summary>
        public EventStoreDomainRepository()
        {             
           
            this.connection = Configuration.CreateConnection();

            var setting = ConnectionSettings.Create()
             .SetDefaultUserCredentials(new UserCredentials("admin", "changeit"));

            var tcpEndPoint = new IPEndPoint(Configuration.EventStoreIP, Configuration.EventStorePort);
            connection = EventStoreConnection.Create(setting, tcpEndPoint);
         }

        /// <summary>
        /// In EventStore each stream has a unique namne (think of a unique road)
        /// and this method is used convert the Aggregate to the StreamName
        /// 
        /// Stream name will depend on the application
        /// 
        /// For example for Marathon runners
        /// a generic formula
        /// 
        /// In our example Category is hard coded
        /// 
        /// </summary>
        /// <param name="type">Aggregate Type which is
        /// location Location as we only have one Aggregate
        /// </param>
        /// <param name="id">This is Location.ID</param>>
        /// <returns></returns>
        private string AggregateToStreamName(Type type, string id)
        {
            return string.Format("{0}-{1}-{2}", Category, type.Name, id);
        }

        // 
        /// <summary>
        /// Here we called this from AddLocationHandler passing the updated
        /// aggregate with the location data contents 
        /// 
        /// </summary>
        /// <typeparam name="TAggregate"></typeparam>
        /// <param name="aggregate"></param>
        /// <param name="isInitial"></param>
        /// <returns></returns>
        public override IEnumerable<IDomainEvent> Save<TAggregate>(TAggregate aggregate, bool isInitial=false)
        {
            // 
            // Here is a list of events that need to be written to
            // the EventStore
            //


            var events = aggregate.UncommitedEvents().ToList();
           
            var originalVersion = aggregate.Version - events.Count;

            var expectedVersion = originalVersion == -1 ? ExpectedVersion.NoStream : originalVersion;

            // Tests here if this is the first time we will write to this stream
            // i.e. the stream has not been created
            // 
            // the code in fact is not complete because true is always been parsed
            // in which case subsequent writes would not be completed
            // to overcome this I have changed the ExpectedVersion to .Any
            // for information see the EventStore documentation
            //
            if (isInitial)
            {
                expectedVersion = ExpectedVersion.NoStream;
            }

            expectedVersion = ExpectedVersion.Any;
            var eventData = events.Select(CreateEventData);
            var streamName = AggregateToStreamName(aggregate.GetType(), aggregate.AggregateId);
            
            //
            // this has been added here so we can connect to EventStore Async
            // I did not want to start changing the pattern I inherited
            // to be totally async friendly        

            StartPoint(streamName, expectedVersion, eventData);                 
            return events;  
        }

        /// <summary>
        /// OK - let's connect then write to the EventStore
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="expectedVersion"></param>
        /// <param name="eventData"></param>
        /// <returns></returns>
        async Task StartPoint(string streamName, int expectedVersion, IEnumerable<EventData> eventData)
        {

               await connection.ConnectAsync();
               await connection.AppendToStreamAsync(streamName, expectedVersion, eventData);
        }

        /// <summary>
        /// OK we look up Events that have been written to event store
        /// so we can build an latest view of the aggregate 
        /// 
        /// Ad we have one Location per event it does not really apply but
        /// in the case of a bank balance, it is vary relevant
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public override TResult GetById<TResult>(string id) 
        {
            var streamName = AggregateToStreamName(typeof(TResult), id);
            var eventsSlice = connection.ReadStreamEventsForwardAsync(streamName, 0, int.MaxValue, false);
            if (eventsSlice.Result.Status == SliceReadStatus.StreamNotFound)
            {
                throw new AggregateNotFoundException("Could not found aggregate of type " + typeof(TResult) + " and id " + id);
            }
            var deserializedEvents = eventsSlice.Result.Events.Select(e =>
            {
                var metadata = SerializationUtils.DeserializeObject<Dictionary<string, string>>(e.OriginalEvent.Metadata);
                var eventData = SerializationUtils.DeserializeObject(e.OriginalEvent.Data, metadata[EventClrTypeHeader]);
                return eventData as IDomainEvent;
            });
            return BuildAggregate<TResult>(deserializedEvents);
        }
    
        public EventData CreateEventData(object @event)
        {
            var eventHeaders = new Dictionary<string, string>()
            {
                {
                    EventClrTypeHeader, @event.GetType().AssemblyQualifiedName
                },
                {
                    "Domain", "Devices"
                }
            };
            var eventDataHeaders = SerializeObject(eventHeaders);
            var data = SerializeObject(@event);
            var eventData = new EventData(Guid.NewGuid(), @event.GetType().Name, true, data, eventDataHeaders);
            return eventData;
        }

        private byte[] SerializeObject(object obj)
        {
            var jsonObj = JsonConvert.SerializeObject(obj);
            var data = Encoding.UTF8.GetBytes(jsonObj);
            return data;
        }

        public string EventClrTypeHeader = "EventClrTypeName";
   
}