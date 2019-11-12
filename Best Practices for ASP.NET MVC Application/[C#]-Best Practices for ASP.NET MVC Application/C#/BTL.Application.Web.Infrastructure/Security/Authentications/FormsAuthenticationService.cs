#region

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BTL.ContractMessages.UserManagement;
using BTL.Infrastructure;
using BTL.Infrastructure.Configuration;
using BTL.Infrastructure.Extensions;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        private readonly IExConfigurationManager _configurationManager;
        private readonly MySettings _settings;

        public FormsAuthenticationService()
            : this(DependencyResolver.Current.GetService<IExConfigurationManager>(),
                    DependencyResolver.Current.GetService<MySettings>())
        {
        }

        public FormsAuthenticationService(IExConfigurationManager configurationManager, MySettings settings)
        {
            _configurationManager = configurationManager;
            _settings = settings;
        }

        #region IFormsAuthenticationService Members

        public void SignIn(string userName,  object userInfo, bool createPersistentCookie)
        {
            Guard.Assert(string.IsNullOrEmpty(userName), "UserName should not be null");
            Guard.MakeSureAllInstancesIsNullNot(_configurationManager, _settings);

            var timeOut = _settings.CookieExpiredTime;

            var expiredDays = _settings.CookieExpiredDay;

            var expirationTime = DateTime.Now.AddMinutes(timeOut);
            if (createPersistentCookie)
            {
                expirationTime = DateTime.Now.AddDays(expiredDays);
            }

            var ticket = new FormsAuthenticationTicket(1,
                                                       userName, DateTime.Now,
                                                       expirationTime,
                                                       createPersistentCookie, userInfo.ToString(),
                                                       FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public HttpCookie GetAuthCookie(string userName, bool createPersistentCookie)
        {
            Guard.Assert(string.IsNullOrEmpty(userName), "UserName should not be null");

            return FormsAuthentication.GetAuthCookie(userName, true);
        }

        public void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            Guard.Assert(string.IsNullOrEmpty(userName), "UserName should not be null");

            FormsAuthentication.SetAuthCookie(userName, true);
        }

        #endregion
    }
}