using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Models
{
    public class BucketModel
    {
        public BucketModel() { }
        public BucketModel(string bucketName, DateTime createdate,string regionName,string url)
        {
            this.BucketName = bucketName;
            this.CreationDate = createdate;
            this.Url = url;
            this.RegionName = regionName;
        }
        public DateTime CreationDate { get; set; }
        public string RegionName { get; set; }
        public string BucketName { get; set; }
        public string Url { get; set; }

    }
}