using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace MvpRestApiLib
{
    public class HttpNotFoundResult : HttpStatusCodeResult
    {
        public HttpNotFoundResult() : this(null) { }

        public HttpNotFoundResult(string statusDescription) : base(404, statusDescription, null) { }
        public HttpNotFoundResult(string statusDescription, string viewName) : base(404, statusDescription, viewName) { }

    }

    public class HttpUnauthorizedResult : HttpStatusCodeResult
    {
        public HttpUnauthorizedResult(string statusDescription) : base(401, statusDescription, null) { }
        public HttpUnauthorizedResult(string statusDescription, string viewName) : base(401, statusDescription, viewName) { }
    }

    public class HttpStatusCodeResult : ViewResult
    {
        public int StatusCode { get; private set; }
        public string StatusDescription { get; private set; }
        public HttpStatusCodeResult(int statusCode) : this(statusCode, null, null) { }

        public HttpStatusCodeResult(int statusCode, string statusDescription, string viewName)
        {
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;
            base.ViewName = viewName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.HttpContext.Response.StatusCode = this.StatusCode;
            if (this.StatusDescription != null)
            {
                context.HttpContext.Response.StatusDescription = this.StatusDescription;
            }

            throw new HttpException(this.StatusCode, this.StatusDescription);                        
        }
    }
}
