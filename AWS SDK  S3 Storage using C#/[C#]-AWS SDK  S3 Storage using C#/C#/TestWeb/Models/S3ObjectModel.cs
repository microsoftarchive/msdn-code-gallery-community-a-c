using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Models
{
    public class S3ObjectModel
    {
        public S3ObjectModel() { }
        public S3ObjectModel(string objectName, string bucketName,string downloadLink )
        {
            this.ObjectName = objectName;
            this.BucketName = bucketName;
            this.DownloadLink = downloadLink;
        }
        public string ObjectName { get; set; }
        public string BucketName { get; set; }
        public string DownloadLink { get; set; }
    }
}