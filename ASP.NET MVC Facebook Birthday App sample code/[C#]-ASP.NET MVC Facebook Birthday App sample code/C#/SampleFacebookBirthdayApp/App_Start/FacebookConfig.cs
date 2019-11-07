using System;
using System.Web.Mvc;
using Microsoft.AspNet.Facebook;
using Microsoft.AspNet.Facebook.Authorization;

namespace SampleFacebookBirthdayApp
{
    public static class FacebookConfig
    {
        public static void Register(FacebookConfiguration configuration)
        {
            // Loads the settings from web.config using the following app setting keys:
            // Facebook:AppId, Facebook:AppSecret, Facebook:AppNamespace
            configuration.LoadFromAppSettings();

            // Adding the authorization filter to check for Facebook signed requests and permissions
            GlobalFilters.Filters.Add(new FacebookAuthorizeFilter(configuration));
        }
    }
}
