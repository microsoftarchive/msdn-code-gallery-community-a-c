using Api_Authorization.Business.UserFactory;
using Api_Authorization.Utility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Api_Authorization.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BasicAuthorization : AuthorizationFilterAttribute
    {
        private const string _authorizedToken = "AuthorizedToken";
        private const string _userAgent = "User-Agent";

        private UserAuthorizations objAuth = null;

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            string authorizedToken = string.Empty;
            string userAgent = string.Empty;

            try
            {
                var headerToken = filterContext.Request.Headers.SingleOrDefault(x => x.Key == _authorizedToken);
                if (headerToken.Key != null)
                {
                    authorizedToken = Convert.ToString(headerToken.Value.SingleOrDefault());
                    userAgent = Convert.ToString(filterContext.Request.Headers.UserAgent);
                    if (!IsAuthorize(authorizedToken, userAgent))
                    {
                        filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        return;
                    }
                }
                else
                {
                    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    return;
                }
            }
            catch (Exception)
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                return;
            }

            base.OnAuthorization(filterContext);
        }

        private bool IsAuthorize(string authorizedToken, string userAgent)
        {
            objAuth = new UserAuthorizations();
            bool result = false;
            try
            {
                result = objAuth.ValidateToken(authorizedToken, userAgent);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}