using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiHelpPage.Models;

namespace WebApiHelpPage
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public abstract class HelpControllerBase : ApiController
    {
        public string HelpPageRouteName = "Default";

        [HttpGet]
        public virtual HttpResponseMessage Index()
        {
            Index template = new Index
            {
                Model = Configuration.Services.GetApiExplorer().ApiDescriptions,
                ApiLinkFactory = apiName =>
                    {
                        string controllerName = Regex.Replace(GetType().Name, "controller", "", RegexOptions.IgnoreCase);
                        return Url.Route(HelpPageRouteName, new { controller = controllerName, apiId = apiName });
                    }
            };
            string helpPage = template.TransformText();
            return new HttpResponseMessage
            {
                Content = new StringContent(helpPage, Encoding.UTF8, "text/html")
            };
        }

        [HttpGet]
        public virtual HttpResponseMessage Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    string controllerName = Regex.Replace(GetType().Name, "controller", "", RegexOptions.IgnoreCase);
                    Api template = new Api
                    {
                        Model = apiModel,
                        HomePageLink = Url.Link(HelpPageRouteName, new { controller = controllerName })
                    };
                    string helpPage = template.TransformText();
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(helpPage, Encoding.UTF8, "text/html")
                    };
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "API not found.");
        }
    }
}