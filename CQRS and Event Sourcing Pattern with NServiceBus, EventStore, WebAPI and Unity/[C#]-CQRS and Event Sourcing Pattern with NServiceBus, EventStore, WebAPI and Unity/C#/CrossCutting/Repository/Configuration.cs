using System.Configuration;
using System.Net;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace CrossCutting.Repository
{
    /// <summary>
    /// OK before we can use the EventStore we must connect to it! 
    /// 
    /// This is a helper class to configure the connection
    /// 
    /// </summary>
    // 
    public static class Configuration
    {
        private static IEventStoreConnection _connection;
        public static IEventStoreConnection CreateConnection()
        {
            return _connection = _connection ?? Connect();
        }

        private static IEventStoreConnection Connect()
        {
            ConnectionSettings settings =
                ConnectionSettings.Create()
                    .UseConsoleLogger()
                    .SetDefaultUserCredentials(new UserCredentials("admin", "changeit"));
            var endPoint = new IPEndPoint(EventStoreIP, EventStorePort);
            var connection = EventStoreConnection.Create(settings, endPoint, null);
            connection.ConnectAsync();
            return connection;
        }

        /// <summary>
        /// For our example we self host on the local host but we can use
        /// Appsettings to get the details
        /// </summary>
        public static IPAddress EventStoreIP
        {
            get
            {
                var hostname = ConfigurationManager.AppSettings["EventStoreHostName"];
                if (string.IsNullOrEmpty(hostname))
                {
                    return IPAddress.Loopback;
                }
                var ipAddresses = Dns.GetHostAddresses(hostname);
                return ipAddresses[0];
            }
        }

        /// <summary>
        /// Although the web portal for the event store is 127.0.0.1:2113 we actually
        /// connect for communicating on 1113
        /// 
        /// </summary>
        public static int EventStorePort
        {
            get
            {
                var esPort = ConfigurationManager.AppSettings["EventStorePort"];
                if (string.IsNullOrEmpty(esPort))
                {
                    return 1113;
                }
                return int.Parse(esPort);
            }
        }
    }
}