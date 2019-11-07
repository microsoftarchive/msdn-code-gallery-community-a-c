#region

using System.Collections.Generic;
using Couchbase;
using Enyim.Caching.Memcached;

#endregion

namespace BTL.Infrastructure.Cache.CouchBase
{
    public class ExCouchbaseMemCached : IExCache
    {
        private readonly CouchbaseClient _memcachedClient;

        public ExCouchbaseMemCached(CouchbaseClient memcachedClient)
        {
            _memcachedClient = memcachedClient;
        }

        #region IExCache Members

        public bool Add(string key, object value)
        {
            return _memcachedClient.Store(StoreMode.Add, key, value);
        }

        public object Get(string key)
        {
            return _memcachedClient.Get(key);
        }

        public IDictionary<string, object> Get(IEnumerable<string> keys)
        {
            return _memcachedClient.Get(keys);
        }

        public TType Get<TType>(string key)
        {
            return _memcachedClient.Get<TType>(key);
        }

        public bool Remove(string key)
        {
            return _memcachedClient.Remove(key);
        }

        public void FlushAll()
        {
            _memcachedClient.FlushAll();
        }

        #endregion
    }
}