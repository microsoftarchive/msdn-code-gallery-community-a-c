#region

using System.Collections.Generic;

#endregion

namespace BTL.Infrastructure.Cache
{
    public interface IExCache
    {
        bool Add(string key, object value);

        object Get(string key);

        IDictionary<string, object> Get(IEnumerable<string> keys);

        TType Get<TType>(string key);

        bool Remove(string key);

        void FlushAll();
    }
}