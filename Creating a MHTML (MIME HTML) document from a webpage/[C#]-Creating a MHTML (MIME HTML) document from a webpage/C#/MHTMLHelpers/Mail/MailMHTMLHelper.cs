using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using MHTMLHelpers.WebRequest;

namespace MHTMLHelpers.Mail
{
    
    public class MailMHTMLHelper : IMHTMLHelper
    {

        private readonly IWebRequestHelper _webRequestHelper;

        public MailMHTMLHelper(IWebRequestHelper webRequestHelper)
        {
            _webRequestHelper = webRequestHelper;
        }

        public byte[] GetMHTML(string url)
        {
            byte[] content;

            var htmlContent = _webRequestHelper.GetContent(url).Content;
            var htmlString = new StringBuilder(Encoding.UTF8.GetString(htmlContent));

            var message = new MailMessage { From = new MailAddress("a@a.com") };

            var resources = new List<LinkedResource>();
            var urlCheck = new Dictionary<string, string>();

            CreateParts(resources, urlCheck, url, htmlString, Patterns.ScriptPattern);
            CreateParts(resources, urlCheck, url, htmlString, Patterns.LinkPattern);
            CreateParts(resources, urlCheck, url, htmlString, Patterns.ImagePattern);

            var view = AlternateView.CreateAlternateViewFromString(htmlString.ToString(), new ContentType("text/html"));
            view.TransferEncoding = TransferEncoding.SevenBit;

            foreach (var resource in resources)
            {
                view.LinkedResources.Add(resource);
            }

            message.AlternateViews.Add(view);

            using (var ms = new MemoryStream())
            {
                message.Write(ms);
                content = new byte[ms.Length];

                var readBytes = 0;
                ms.Position = 0;
                while (readBytes < ms.Length)
                {
                    readBytes += ms.Read(content, 0, (int)ms.Length - readBytes);
                }
            }

            return content;
        }

        private void CreateParts(List<LinkedResource> resources, Dictionary<string, string> urlCheck, string baseUrl, StringBuilder htmlString, Regex pattern)
        {
            foreach (Match m in pattern.Matches(htmlString.ToString()))
            {
                var url = m.Groups["Url"].Value;
                var absoluteUrl = _webRequestHelper.GetAbsoluteUrl(baseUrl, url);

                if (!urlCheck.ContainsKey(absoluteUrl))
                {
                    var id = Guid.NewGuid().ToString();

                    var result = _webRequestHelper.GetContent(absoluteUrl);

                    var ms = new MemoryStream(result.Content);
                    var lr = new LinkedResource(ms, new ContentType(result.ContentType)) {ContentId = id, TransferEncoding = TransferEncoding.Base64};
                    resources.Add(lr);

                    htmlString.Replace(url, "cid:" + id);

                    urlCheck.Add(absoluteUrl, result.FileName);
                }
            }
        }

    }
}
