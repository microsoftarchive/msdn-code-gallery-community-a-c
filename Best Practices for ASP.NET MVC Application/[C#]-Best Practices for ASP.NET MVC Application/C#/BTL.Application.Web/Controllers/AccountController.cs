#region

using System;
using System.Web.Mvc;
using BTL.Application.Web.Infrastructure;
using BTL.Application.Web.Infrastructure.Security.Authentications;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.FacebookAuthentication;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.GoogleAuthentication;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.TwitterAuthentication;
using BTL.ContractMessages.UserManagement;
using BTL.Infrastructure;
using BTL.Infrastructure.Configuration;
using BTL.Infrastructure.Extensions;

#endregion

namespace BTL.Application.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IFormsAuthenticationService _formsAuthenticationService;
        private readonly MySettings _mySettings;
        private string _consumerKey = string.Empty;
        private string _secretKey = string.Empty;
        private InMemoryTokenManager _tokenManager;

        public AccountController()
            : this(DependencyResolver.Current.GetService<IFormsAuthenticationService>(),
                   DependencyResolver.Current.GetService<MySettings>())
        {
        }

        public AccountController(
            IFormsAuthenticationService formsAuthenticationService,
            MySettings mySettings)
        {
            _formsAuthenticationService = formsAuthenticationService;
            _mySettings = mySettings;
        }

        public ActionResult LogOn()
        {
            if (Request.IsAuthenticated)
            {
                return
                    RedirectToAction("Index", "Home");
            }

            Session["ReturnUrl"] =
                Request.QueryString["returnUrl"];

            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(AuthRequestType authType)
        {
            Guard.MakeSureAllInstancesIsNullNot(_mySettings);

            var redirectUrl = string.Empty;

            switch (authType)
            {
                case AuthRequestType.Facebook:
                    var facebookContext = new FacebookAuthRequestProcessingContext();
                    var facebookInputParam = new FacebookAuthRequestProcessingParameter
                                                 {
                                                     RequestUrl = HttpContext.Request.GetUrlBase(),
                                                     RedirectPath = Url.Action("FacebookCallbackAction")
                                                 };

                    facebookContext.Execute(() => facebookInputParam);

                    redirectUrl = facebookContext.ReturnResult;
                    break;

                case AuthRequestType.Twitter:

                    var twitterContext = new TwitterAuthRequestProcessingContext();

                    var twitterCallbackUrl = Request.Url.ToString().Replace("Authenticate", "TwitterCallbackAction");
                    var twitterCallback = new Uri(twitterCallbackUrl);

                    _consumerKey = _mySettings.TwitterConsumerKey;
                    _secretKey = _mySettings.TwitterConsumerSecret;

                    AssertForKeyAndSecretConsummer(_consumerKey, _secretKey);

                    _tokenManager = new InMemoryTokenManager(_consumerKey, _secretKey);

                    var twitterInputParam = new TwitterAuthRequestProcessingParameter
                                                {
                                                    CallBackLink = twitterCallback,
                                                    TokenManager = _tokenManager
                                                };

                    twitterContext.Execute(() => twitterInputParam);

                    HttpContext.Application["TwitterTokenManager"] = _tokenManager;

                    return twitterContext.ReturnResult;

                    break;

                case AuthRequestType.Google:
                    var googleContext = new GoogleAuthRequestProcessingContext();

                    var callbackUrl = Request.Url.ToString().Replace("Authenticate", "GoogleCallbackAction");
                    var callback = new Uri(callbackUrl);

                    _consumerKey = _mySettings.GoogleConsumerKey;
                    _secretKey = _mySettings.GoogleConsumerSecret;

                    AssertForKeyAndSecretConsummer(_consumerKey, _secretKey);

                    _tokenManager = new InMemoryTokenManager(_consumerKey, _secretKey);

                    var googleInputParam = new GoogleAuthRequestProcessingParameter
                                               {
                                                   CallBackLink = callback,
                                                   TokenManager = _tokenManager
                                               };

                    googleContext.Execute(() => googleInputParam);

                    HttpContext.Application["GoogleTokenManager"] = _tokenManager;

                    return googleContext.ReturnResult;

                    break;
            }

            return Redirect(redirectUrl);
        }

        public ActionResult TwitterCallbackAction()
        {
            var twitterContext = new TwitterAuthRequestProcessedContext();

            var twitterInputParam = new TwitterAuthRequestProcessedParameter
                                        {
                                            TokenManager =
                                                HttpContext.Application["TwitterTokenManager"] as InMemoryTokenManager
                                        };

            twitterContext.Execute(() => twitterInputParam);

            SocialUserInformation userData = twitterContext.ReturnResult;

            SignIn(userData);

            return GetHomeAction();
        }

        public ActionResult GoogleCallbackAction()
        {
            var googleContext = new GoogleAuthRequestProcessedContext();

            var googleInputParam = new GoogleAuthRequestProcessedParameter
                                       {
                                           TokenManager =
                                               HttpContext.Application["GoogleTokenManager"] as InMemoryTokenManager
                                       };

            googleContext.Execute(() => googleInputParam);

            SocialUserInformation userData = googleContext.ReturnResult;

            SignIn(userData);

            return GetHomeAction();
        }

        /// <summary>
        ///   This method using for callback when we use Facebook or Windows Live for authetication
        /// </summary>
        /// <returns> </returns>
        public ActionResult FacebookCallbackAction()
        {
            var facebookContext = new FacebookAuthRequestProcessedContext();
            facebookContext.Execute(() => null);
            SocialUserInformation userData = facebookContext.ReturnResult;

            if (userData == null)
            {
                TempData["authError"] =
                    "Authentication has failed.";

                return
                    RedirectToAction("LogOn");
            }

            // TODO: have to store user information to database here
            // ...

            SignIn(userData);

            return GetHomeAction();
        }

        private ActionResult GetHomeAction()
        {
            return Session["ReturnUrl"] != null
                       ? (ActionResult) Redirect((string) Session["ReturnUrl"])
                       : RedirectToAction("Index", "Home");
        }

        private void SignIn(SocialUserInformation userData)
        {
            _formsAuthenticationService.SignIn(userData.UserName, userData, false);
        }

        private static void AssertForKeyAndSecretConsummer(string consumerKey, string secretKey)
        {
            Guard.Assert(string.IsNullOrEmpty(consumerKey) || string.IsNullOrEmpty(secretKey),
                         "ConsumerKey and SecretKey should not be null");
        }
    }
}