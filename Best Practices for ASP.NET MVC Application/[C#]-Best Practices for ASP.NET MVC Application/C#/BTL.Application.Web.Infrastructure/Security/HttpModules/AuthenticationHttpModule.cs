#region

using System.Threading;
using System.Web;
using BTL.ContractMessages.UserManagement;
using BTL.Infrastructure;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.HttpModules
{
    public abstract class AuthenticationHttpModule : HttpModuleBase
    {
        public override void AuthenticateRequest(HttpContext httpContext)
        {
            base.AuthenticateRequest(httpContext);

            if (httpContext == null || httpContext.User == null || !httpContext.User.Identity.IsAuthenticated) return;

            var token = string.Empty;

            if (ValidateToken(token))
            {
                var principal = new UserPrincipal(httpContext.User.Identity, GetUser());

                httpContext.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            else
            {
                LogOff();
            }
        }

        public abstract UserInfo GetUser();

        public virtual bool ValidateToken(string token)
        {
            return true;
        }

        public virtual void LogOff()
        {
        }
    }
}