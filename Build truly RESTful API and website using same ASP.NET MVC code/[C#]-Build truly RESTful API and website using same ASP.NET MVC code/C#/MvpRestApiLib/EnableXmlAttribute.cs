using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvpRestApiLib
{
    public class EnableXmlAttribute : ActionFilterAttribute
    {
        private readonly static string[] _xmlTypes = new string[] { "application/xml", "text/xml" };

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (typeof(RedirectToRouteResult).IsInstanceOfType(filterContext.Result))
                return;

            var acceptTypes = filterContext.HttpContext.Request.AcceptTypes ?? new[] { "text/html" };

            var model = filterContext.Controller.ViewData.Model;

            var contentEncoding = filterContext.HttpContext.Request.ContentEncoding ?? Encoding.UTF8;

            if (_xmlTypes.Any(type => acceptTypes.Contains(type)))
                filterContext.Result = new XmlResult()
                {
                    Data = model,
                    ContentEncoding = contentEncoding,
                    ContentType = filterContext.HttpContext.Request.ContentType
                };
        }
    }
}
