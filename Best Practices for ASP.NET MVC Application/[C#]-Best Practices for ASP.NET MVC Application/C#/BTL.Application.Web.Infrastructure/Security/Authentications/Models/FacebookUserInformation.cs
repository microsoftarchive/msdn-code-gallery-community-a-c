#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.FacebookAuthentication;
using BTL.Infrastructure;
using DotNetOpenAuth.ApplicationBlock;
using Newtonsoft.Json.Linq;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Models
{
    public class FacebookUserInformation : UserRequestInformation, IFacebookAuthRequestRole
    {
        private readonly FacebookClient _facebookClient;
        private readonly MySettings _mySettings;

        public FacebookUserInformation()
            : this(DependencyResolver.Current.GetService<FacebookClient>(),
                   DependencyResolver.Current.GetService<MySettings>())
        {
        }

        public FacebookUserInformation(FacebookClient facebookClient, MySettings mySettings)
        {
            Guard.MakeSureAllInstancesIsNullNot(mySettings);

            _facebookClient = facebookClient;
            _mySettings = mySettings;
            _facebookClient = facebookClient;
            _facebookClient.ClientIdentifier = _mySettings.FacebookAppId;
            _facebookClient.ClientSecret = _mySettings.FacebookAppSecret;
        }

        public void ProcessAuthRequest()
        {
            var authorization = _facebookClient.ProcessUserAuthorization();

            if (authorization.AccessToken == null)
            {
                return;
            }

            var graphRequest = WebRequest.Create(
                "https://graph.facebook.com/me?access_token=" + Uri.EscapeDataString(authorization.AccessToken));

            using (var response = graphRequest.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var streamReader = new StreamReader(responseStream))
            {
                var jsonText = streamReader.ReadToEnd();
                var jsonObject = JObject.Parse(jsonText);

                UserId = jsonObject["id"].ToString();
                UserName = jsonObject["name"].ToString();
                PictureUrl = string.Format("http://graph.facebook.com/{0}/picture", jsonObject["id"]);
            }
        }

        public string PrepareAuthRequest(string requestUrl, string redirectPath,
                                                  IDictionary<string, string> parameters = null)
        {
            var authorization = _facebookClient.ProcessUserAuthorization();

            var callback = new Uri(requestUrl + redirectPath);

            if (authorization == null)
            {
                return _facebookClient
                    .PrepareRequestUserAuthorization(returnTo: callback)
                    .Headers["Location"];
            }

            return null;
        }
    }
}