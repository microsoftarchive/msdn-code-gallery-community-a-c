using MainWeb.Helpers;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Http;

namespace WopHost.Controllers.Api
{
    public class LinkController : ApiController
    {
        /// <summary>
        /// Provides a link that can be used to Open a document in the relative viewer
        /// from the Office Web Apps server
        /// </summary>
        /// <param name="fileRequest">indicates the request type</param>
        /// <returns>A link usable for HREF</returns>
        public Link GetLink([FromUri] FileRequest fileRequest)
        {
            if (ModelState.IsValid)
            {
                var xml = WebConfigurationManager.AppSettings["appDiscoveryXml"];
                var wopiServer = WebConfigurationManager.AppSettings["appWopiServer"];
                bool updateEnabled = false;
                bool.TryParse(WebConfigurationManager.AppSettings["updateEnabled"], out updateEnabled);
                WopiAppHelper wopiHelper = new WopiAppHelper(HostingEnvironment.MapPath(xml), updateEnabled);

                var result = wopiHelper.GetDocumentLink(wopiServer + fileRequest.name);

                var rv = new Link
                {
                    Url = result
                };
                return rv;
            }

            throw new ApplicationException("Invalid ModelState");
        }
    }
}
