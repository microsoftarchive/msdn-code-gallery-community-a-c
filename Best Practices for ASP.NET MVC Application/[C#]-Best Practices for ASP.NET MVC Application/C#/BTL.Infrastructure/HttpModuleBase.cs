#region

using System;
using System.Web;

#endregion

namespace BTL.Infrastructure
{
    public abstract class HttpModuleBase : IHttpModule
    {
        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += ContextAuthenticateRequest;
        }

        public void Dispose()
        {
            //not implemented
        }

        #endregion

        private void ContextAuthenticateRequest(object sender, EventArgs e)
        {
            var appliction = (HttpApplication) sender;
            AuthenticateRequest(appliction.Context);
        }

        public virtual void AuthenticateRequest(HttpContext httpContext)
        {
            //not implemented
        }
    }
}