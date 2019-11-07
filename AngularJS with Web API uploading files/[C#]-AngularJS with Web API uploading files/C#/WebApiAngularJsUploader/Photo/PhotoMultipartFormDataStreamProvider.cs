using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApiAngularJsUploader.Photo
{
    public class PhotoMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
    
        public PhotoMultipartFormDataStreamProvider(string path) : base(path)    
        {
        }
 
        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            //Make the file name URL safe and then use it & is the only disallowed url character allowed in a windows filename
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            return name.Trim(new char[] { '"' })
                        .Replace("&", "and");                        
        }
    }
}