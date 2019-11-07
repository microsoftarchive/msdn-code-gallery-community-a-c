#region

using System.Web.Mvc;

#endregion

namespace BTL.Infrastructure.Cache
{
    public class CacheProvider : ICacheProvider
    {
        private static readonly object _lockObject = new object();

        #region ICacheProvider Members

        public IExCache Instance
        {
            get
            {
                lock (_lockObject)
                {
                    return DependencyResolver.Current.GetService<IExCache>();
                }
            }
        }

        #endregion
    }
}