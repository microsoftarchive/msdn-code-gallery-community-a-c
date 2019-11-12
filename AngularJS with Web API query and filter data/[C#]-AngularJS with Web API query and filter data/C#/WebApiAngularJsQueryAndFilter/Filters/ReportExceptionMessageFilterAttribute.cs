using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiAngularJsQueryAndFilter.Filters
{
    public class ReportExceptionMessageFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                context.Exception.GetBaseException().Message);
        }
    }
}