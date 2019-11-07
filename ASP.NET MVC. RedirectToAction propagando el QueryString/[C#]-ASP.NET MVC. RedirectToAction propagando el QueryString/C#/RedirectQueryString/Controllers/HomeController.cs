using RedirectQueryString.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RedirectQueryString.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            string result = "Action: Index<br/>";
            result += "<b>RouteData</b><br/>";
            foreach (string key in RouteData.Values.Keys)
                result += string.Format("{0}: {1}<br/>", key, RouteData.Values[key]);
            result += "<b>QueryString</b><br/>";
            foreach (string key in Request.QueryString.AllKeys)
                result += string.Format("{0}: {1}<br/>", key, Request.QueryString[key]);
            return result;
        }

        public RedirectToRouteResult Redirect()
        {
            RouteValueDictionary routeData = new RouteValueDictionary();
            foreach (string key in Request.QueryString.AllKeys)
                routeData.Add(key, Request.QueryString[key]);
            return RedirectToAction("Index", routeData);
        }

        [PropagarQueryString]
        public RedirectToRouteResult RedirectQueryString()
        {
            return RedirectToAction("Index");
        }

    }
}