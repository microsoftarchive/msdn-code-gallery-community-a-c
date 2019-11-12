using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon;
using Amazon.S3;

namespace TestWeb.Utilities.Common
{
    public class AWSService : IAWSServce
    {
        public AWSService() { }
        //public AWSService(string accessKey,string secretkey,RegionEndpoint regionEndpoint )
        //{
        //    this.AccessKey = accessKey;
        //    this.SecretKey = secretkey;
        //    this.RegionEndpoint = regionEndpoint;
        //}
        public virtual IAmazonS3 Client {
            get { return Amazon.AWSClientFactory.CreateAmazonS3Client(Config.AccessKey,Config.SecretKey,RegionEndpoint.APNortheast1); }
        }

        //public string AccessKey { get; set; }
        //public string SecretKey { get; set; }
        //public RegionEndpoint RegionEndpoint {
        //    get { return RegionEndpoint.APNortheast2; }
        //    set { RegionEndpoint = value; }
        //}
    }
}