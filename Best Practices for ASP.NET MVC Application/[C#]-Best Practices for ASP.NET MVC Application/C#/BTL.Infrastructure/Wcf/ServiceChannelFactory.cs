#region

using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

#endregion

namespace BTL.Infrastructure.Wcf
{
    public static class ServiceChannelFactory<T> where T : class
    {
        // Fields
        private static readonly ReaderWriterLockSlim CollectionLock;

        // Methods
        static ServiceChannelFactory()
        {
            CollectionLock = new ReaderWriterLockSlim();
        }

        public static void Abort(T channel)
        {
            if (channel != null)
            {
                ((ICommunicationObject) channel).Abort();
            }
        }

        public static void Close(T channel)
        {
            if (channel != null)
            {
                ((ICommunicationObject) channel).Close();
            }
        }

        public static IChannel GetChannel(string endpointName)
        {
            ChannelFactory<T> factory = null;
            CollectionLock.EnterUpgradeableReadLock();
            try
            {
                if (ChannelStore.Instance.ProxyCollection.Keys.Contains(endpointName))
                {
                    factory = (ChannelFactory<T>) ChannelStore.Instance.ProxyCollection[endpointName];
                }
                else
                {
                    factory = new ChannelFactory<T>(endpointName);
                    CollectionLock.EnterWriteLock();
                    try
                    {
                        ChannelStore.Instance.ProxyCollection.Add(endpointName, factory);
                    }
                    finally
                    {
                        CollectionLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                CollectionLock.ExitUpgradeableReadLock();
            }
            return (IChannel) factory.CreateChannel();
        }
    }


    public sealed class ChannelStore
    {
        // Fields
        private static volatile ChannelStore _instance;
        private static readonly object SyncRoot = new object();
        public Dictionary<string, ChannelFactory> ProxyCollection = new Dictionary<string, ChannelFactory>();

        // Methods
        private ChannelStore()
        {
        }

        // Properties
        public static ChannelStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new ChannelStore();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}