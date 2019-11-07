using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TodoListService
{
    public class HttpResponseActionResult : HttpStatusCodeResult
    {
        string authenticateValue;

        public HttpResponseActionResult(string authenticateValue)
            : base(HttpStatusCode.Unauthorized)
        {
            this.authenticateValue = authenticateValue;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.AppendHeader("WWW-Authenticate", this.authenticateValue);
            base.ExecuteResult(context);
        }
    }
}
