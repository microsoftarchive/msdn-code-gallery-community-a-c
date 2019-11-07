using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvpRestApiLib
{
    public class EnableJsonAttribute : ActionFilterAttribute
    {
        private readonly static string[] _jsonTypes = new string[] { "application/json", "text/json" };
        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (typeof(RedirectToRouteResult).IsInstanceOfType(filterContext.Result))
                return;

            var acceptTypes = filterContext.HttpContext.Request.AcceptTypes ?? new[] { "text/html" };

            var model = filterContext.Controller.ViewData.Model;

            var contentEncoding = filterContext.HttpContext.Request.ContentEncoding ?? Encoding.UTF8;

            if (_jsonTypes.Any(type => acceptTypes.Contains(type)))
                filterContext.Result = new JsonResult2() 
                { 
                    Data = model, 
                    ContentEncoding = contentEncoding,
                    ContentType = filterContext.HttpContext.Request.ContentType
                };            
        }
    }
}
