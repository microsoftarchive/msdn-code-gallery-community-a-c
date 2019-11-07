using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace TestWeb.Utilities.Common
{
    public static class Config
    {
        public static string AccessKey{ get { return ConfigurationManager.AppSettings["AWSAccessKey"]; } }
        public static string SecretKey { get { return ConfigurationManager.AppSettings["AWSSecretKey"]; } }
    }
}