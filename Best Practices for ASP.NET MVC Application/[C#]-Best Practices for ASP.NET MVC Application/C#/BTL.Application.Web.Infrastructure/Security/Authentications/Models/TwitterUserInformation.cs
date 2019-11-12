#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.Mvc;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.TwitterAuthentication;
using DotNetOpenAuth.ApplicationBlock;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Models
{
    public class TwitterUserInformation : UserRequestInformation, ITwitterAuthRequestRole
    {
        private WebConsumer _webConsumer;

        #region ITwitterAuthRequestRole Members

        public void ProcessAuthRequest(IConsumerTokenManager tokenManager)
        {
            _webConsumer = new WebConsumer(TwitterConsumer.SignInWithTwitterServiceDescription, tokenManager);

            var response = _webConsumer.ProcessUserAuthorization();

            if (response == null)
            {
                return;
            }

            var screenName = response.ExtraData["screen_name"];
            var userId = int.Parse(response.ExtraData["user_id"]);

            UserId = userId.ToString(CultureInfo.CurrentCulture);
            UserName = screenName;
            PictureUrl = string.Format("http://api.twitter.com/1/users/profile_image/{0}.png", screenName);
        }

        public ActionResult PrepareAuthRequest(Uri callback, IConsumerTokenManager tokenManager)
        {
            _webConsumer = new WebConsumer(TwitterConsumer.SignInWithTwitterServiceDescription, tokenManager);

            var token = GetAccessToken();

            if (string.IsNullOrEmpty(token))
            {
                var redirectParameters = new Dictionary<string, string>();

                redirectParameters["force_login"] = "false";

                var request = _webConsumer.PrepareRequestUserAuthorization(callback, null, redirectParameters);

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