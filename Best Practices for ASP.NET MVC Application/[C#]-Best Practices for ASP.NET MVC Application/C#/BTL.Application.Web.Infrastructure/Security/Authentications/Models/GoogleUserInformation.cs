#region

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Web.Mvc;
using System.Xml.Linq;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.GoogleAuthentication;
using BTL.Infrastructure;
using BTL.Infrastructure.Configuration;
using DotNetOpenAuth.ApplicationBlock;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using DotNetOpenAuth.OAuth.Messages;
using Newtonsoft.Json.Linq;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Models
{
    public class GoogleUserInformation : UserRequestInformation, IGoogleAuthRequestRole
    {
        private WebConsumer _webConsumer;

        private readonly MessageReceivingEndpoint _getUserInfoEndpoint = 
            new MessageReceivingEndpoint("https://www.googleapis.com/oauth2/v2/userinfo?pp=1&key=", HttpDeliveryMethods.GetRequest);

        #region IGoogleAuthRequestRole Members

        public void ProcessAuthRequest(IConsumerTokenManager tokenManager)
        {
            _webConsumer = new WebConsumer(GoogleConsumer.ServiceDescription, tokenManager);

            var accessToken = GetAccessToken();

            if (string.IsNullOrEmpty(accessToken)) 
                throw new NoNullAllowedException("AccessToken should not be null");

            var request = _webConsumer.PrepareAuthorizedRequest(_getUserInfoEndpoint, accessToken);
            var response = _webConsumer.Channel.WebRequestHandler.GetResponse(request);
            var json = response.GetResponseReader().ReadToEnd();
            
            var jsonObject = JObject.Parse(json);
            UserId = jsonObject["id"].ToString();
            UserName = jsonObject["name"].ToString();
            PictureUrl = jsonObject["picture"].ToString();
        }

        public ActionResult PrepareAuthRequest(Uri callback, IConsumerTokenManager tokenManager)
        {
            _webConsumer = new WebConsumer(GoogleConsumer.ServiceDescription, tokenManager);

            var accessToken = GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                var extraParameters = new Dictionary<string, string>();

                extraParameters.Add("scope", "https://www.googleapis.com/auth/userinfo.profile");
                var request = _webConsumer.PrepareRequestUserAuthorization(callback, extraParameters, null);

                return _webConsumer.Channel.PrepareResponse(request).AsActionResult();
            }

            return null;
        }

        #endregion

        private string GetAccessToken()
        {
            var accessTokenResponse = _webConsumer.ProcessUserAuthorization();

            return accessTokenResponse != null ? accessTokenResponse.AccessToken : null;
        }
    }
}