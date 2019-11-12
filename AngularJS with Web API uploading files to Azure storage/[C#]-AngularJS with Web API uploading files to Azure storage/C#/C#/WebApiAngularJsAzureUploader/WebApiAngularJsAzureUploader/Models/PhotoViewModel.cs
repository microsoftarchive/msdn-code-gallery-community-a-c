using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAngularJsAzureUploader.Models
{
    public class PhotoViewModel
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public long Size { get; set; }
        public string Url { get; set; }

    }
}