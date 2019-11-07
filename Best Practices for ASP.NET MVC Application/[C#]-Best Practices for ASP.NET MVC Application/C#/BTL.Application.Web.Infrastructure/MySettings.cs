#region

using System.Collections.Generic;
using BTL.Infrastructure.Configuration;

#endregion

namespace BTL.Application.Web.Infrastructure
{
    public class MySettings : ISectionConfiguration
    {
        public const string SECTION_NAME = "BTL.Applications/MySettings";

        public string SecretKey { get; set; }

        public int CookieExpiredTime { get; set; }

        public int CookieExpiredDay { get; set; }

        public string FacebookAppId { get; set; }

        public string FacebookAppSecret { get; set; }

        public string TwitterConsumerKey { get; set; }

        public string TwitterConsumerSecret { get; set; }

        public string GoogleConsumerKey { get; set; }

        public string GoogleConsumerSecret { get; set; }

        #region ISectionConfiguration Members

        public void Add(string sectionName, string sectionValue, List<KeyValuePair<string, string>> valuePairs)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}