using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedirectQueryString.Code
{
    public class PropagarQueryStringAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var redirectResult = filterContext.Result as RedirectToRouteResult;
            if (redirectResult != null)
            {
                NameValueCollection query = filterContext.HttpContext.Request.QueryString;
                foreach (string key in query.Keys)
                {
                    if (!redirectResult.RouteValues.ContainsKey(key))
                        redirectResult.RouteValues.Add(key, query[key]);
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}