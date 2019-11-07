using System;
using System.IO;
using System.Net;

namespace MHTMLHelpers.WebRequest
{

    public class WebRequestHelper : IWebRequestHelper
    {

        private const string ContentDispositionHeaderName = "Content-Disposition";

        public WebRequestResult GetContent(String url)
        {
            var result = new WebRequestResult();

            try
            {
                var request = (HttpWebRequest)System.Net.WebRequest.Create(url);
                request.ServicePoint.Expect100Continue = false;

                var response = (HttpWebResponse)request.GetResponse();

                if ((response.ContentLength > 0) || (response.StatusCode == HttpStatusCode.OK))
                {
                    //also handles chunked transfer encoding where we don't know the content length
                    using (var ms = new MemoryStream())
                    {
                        using (var br = new BinaryReader(response.GetResponseStream()))
                        {
                            var buffer = new byte[1024];
                            int readBytes;
                            do
                            {
                                readBytes = br.Read(buffer, 0, buffer.Length);
                                ms.Write(buffer, 0, readBytes);
                            } while (readBytes > 0);
                        }

                        ms.Position = 0;
                        result.Content = new byte[ms.Length];
                        var writtenBytes = 0;
                        while (writtenBytes < ms.Length)
                        {
                            writtenBytes += ms.Read(result.Content, writtenBytes, (int)ms.Length - writtenBytes);
                        }
                    }

                    result.Url = url;
                    result.ContentType = response.ContentType;

                    //try to get file name from response header since dynamically generated resource may not include name
                    var contentDisposition = response.Headers[ContentDispositionHeaderName];
                    if (!string.IsNullOrEmpty(contentDisposition))
                    {
                        var match = Patterns.FileNamePattern.Match(contentDisposition);
                        if (match.Success)
                        {
                            result.FileName = match.Groups["FileName"].Value;
                        }
                    }

                    //if no content-disposition header is not present, try to get the file name from url
                    if (string.IsNullOrEmpty(result.FileName))
                    {
                        var uri = new Uri(url);
                        result.FileName = Path.GetFileName(uri.AbsolutePath);
                    }
                }
            }
            catch (Exception) { }

            return result;
        }

        public string GetAbsoluteUrl(string baseUrl, string url)
        {
            if (url.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase))
                return url;

            var uri = new Uri(baseUrl);
            var basePath = uri.AbsolutePath.Substring(0, uri.AbsolutePath.LastIndexOf("/"));
            return uri.GetLeftPart(UriPartial.Authority) + Path.Combine(basePath, url);
        }

    }

}
