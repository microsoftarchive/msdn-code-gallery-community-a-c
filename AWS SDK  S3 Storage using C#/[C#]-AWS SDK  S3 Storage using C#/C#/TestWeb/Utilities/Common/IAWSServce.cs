using Amazon.S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Utilities.Common
{
    public interface IAWSServce
    {
        IAmazonS3 Client { get; }
    }
}