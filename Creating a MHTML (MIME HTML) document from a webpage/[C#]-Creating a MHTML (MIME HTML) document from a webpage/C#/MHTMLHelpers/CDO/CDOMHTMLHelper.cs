using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using CDO;
using MHTMLHelpers.WebRequest;

namespace MHTMLHelpers.CDO
{

    public class CDOMHTMLHelper : IMHTMLHelper
    {

        private readonly IWebRequestHelper _webRequestHelper;

        public CDOMHTMLHelper(IWebRequestHelper webRequestHelper)
        {
            _webRequestHelper = webRequestHelper;
        }

        public byte[] GetMHTML(string url)
        {
            Message message = new MessageClass {MimeFormatted = true};

            message.CreateMHTMLBody(url, CdoMHTMLFlags.cdoSuppressNone, "", "");

            CreateScriptParts(message, url);

            var stream = message.GetStream();
            var content = new byte[stream.Size];

            var iStream = (IStream)stream;
            iStream.Read(content, content.Length, IntPtr.Zero);
            stream.Close();

            return content;
        }

        private void CreateScriptParts(Message message, string baseUrl)
        {
            var html = message.HTMLBody;

            //unlikey to have same js multiple times...
            foreach (Match m in Patterns.ScriptPattern.Matches(html))
            {
                var scriptUrl = m.Groups["Url"].Value;
                var absoluteScriptUrl = _webRequestHelper.GetAbsoluteUrl(baseUrl, scriptUrl);
                var id = Guid.NewGuid().ToString();

                var scriptPart = message.BodyPart.AddBodyPart();
                scriptPart.ContentMediaType = "text/javascript";
                scriptPart.Charset = "iso-8859-1";
                scriptPart.ContentTransferEncoding = "quoted-printable";
                scriptPart.Fields["urn:schemas:mailheader:content-id"].Value = id;
                scriptPart.Fields["urn:schemas:mailheader:content-disposition"].Value = "inline";
                scriptPart.Fields.Update();

                var stream = scriptPart.GetDecodedContentStream();
                var scriptStream = (IStream)stream;
                var scriptContent = _webRequestHelper.GetContent(absoluteScriptUrl);
                scriptStream.Write(scriptContent.Content, scriptContent.Content.Length, IntPtr.Zero);
                stream.Flush();
                stream.Close();
            
                message.HTMLBody = message.HTMLBody.Replace(scriptUrl, "cid:" + id);
            }
        }

    }

}
