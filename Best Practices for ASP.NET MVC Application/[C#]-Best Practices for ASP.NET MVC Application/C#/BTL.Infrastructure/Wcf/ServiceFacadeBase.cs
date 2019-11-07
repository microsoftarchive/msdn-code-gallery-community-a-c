#region

using System.Reflection;

#endregion

namespace BTL.Infrastructure.Wcf
{
    public abstract class ServiceFacadeBase<TService> where TService : class
    {
        private TService _service;

        protected abstract string ServiceName { get; }

        public TService Service
        {
            get { return _service ?? (_service = (TService) ServiceChannelFactory<TService>.GetChannel(ServiceName)); }
        }

        // TODO: have to write log message to event log
        protected void LogError(object exception, MethodBase methodBase, bool throwError)
        {
            //throw new NotImplementedException();
        }
    }
}