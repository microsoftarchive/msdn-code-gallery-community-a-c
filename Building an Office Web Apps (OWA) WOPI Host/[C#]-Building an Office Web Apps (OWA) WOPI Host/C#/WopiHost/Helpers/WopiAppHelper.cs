using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Xml.Serialization;

namespace MainWeb.Helpers
{
    public class WopiAppHelper
    {
        string _discoveryFile;
        bool _updateEnabled = false;
        WopiHost.wopidiscovery _wopiDiscovery;

        public WopiAppHelper(string discoveryXml)
        {
            _discoveryFile = discoveryXml;

            using (StreamReader file = new StreamReader(discoveryXml))
            {
                XmlSerializer reader = new XmlSerializer(typeof(WopiHost.wopidiscovery));
                var wopiDiscovery = reader.Deserialize(file) as WopiHost.wopidiscovery;
                _wopiDiscovery = wopiDiscovery;
            }
        }

        public WopiAppHelper(string discoveryXml, bool updateEnabled)
            : this(discoveryXml)
        {
            _updateEnabled = updateEnabled;
        }

        public WopiHost.wopidiscoveryNetzoneApp GetZone(string AppName)
        {
            var rv = _wopiDiscovery.netzone.app.Where(c => c.name == AppName).FirstOrDefault();
            return rv;
        }

        public string GetDocumentLink(string wopiHostandFile)
        {
            var fileName = wopiHostandFile.Substring(wopiHostandFile.LastIndexOf('/') + 1);
            var accessToken = GetToken(fileName);
            var fileExt = fileName.Substring(fileName.LastIndexOf('.') + 1);
            var netzoneApp = _wopiDiscovery.netzone.app.AsEnumerable()
                .Where(c => c.action.Where(d => d.ext == fileExt).Count() > 0);

            var appName = netzoneApp.FirstOrDefault();

            if (null == appName) throw new ArgumentException("invalid file extension " + fileExt);

            var rv = GetDocumentLink(appName.name, fileExt, wopiHostandFile, accessToken);

            return rv;
        }

        string GetToken(string fileName)
        {
            KeyGen keyGen = new KeyGen();
            var rv = keyGen.GetHash(fileName);

            return HttpUtility.UrlEncode(rv);
        }

        const string s_WopiHostFormat = "{0}?WOPISrc={1}&access_token={2}";
        //HACK:
        const string s_WopiHostFormatPdf = "{0}?PdfMode=1&WOPISrc={1}&access_token={2}";

        public string GetDocumentLink(string appName, string fileExtension, string wopiHostAndFile, string accessToken)
        {
            var wopiHostUrlsafe = HttpUtility.UrlEncode(wopiHostAndFile.Replace(" ", "%20"));
            var appStuff = _wopiDiscovery.netzone.app.Where(c => c.name == appName).FirstOrDefault();

            if (null == appStuff)
                throw new ApplicationException("Can't locate App: " + appName);

            var action = _updateEnabled ? "edit" : "view";

            var appAction = appStuff.action.Where(c => c.ext == fileExtension && c.name == action).FirstOrDefault();

            if (null == appAction)
                throw new ApplicationException("Can't locate UrlSrc for : " + appName);

            var endPoint = appAction.urlsrc.IndexOf('?');
            var endAction = appAction.urlsrc.Substring(0, endPoint);

            string fullPath = null;
            ////HACK: for PDF now just append WordPdf option...
            if (fileExtension.Contains("pdf"))
            {
                fullPath = string.Format( s_WopiHostFormatPdf, endAction, wopiHostUrlsafe, accessToken);
            }
            else
            {
                fullPath = string.Format(s_WopiHostFormat, endAction,  wopiHostUrlsafe, accessToken);
            }

            return fullPath;
        }
    }
}