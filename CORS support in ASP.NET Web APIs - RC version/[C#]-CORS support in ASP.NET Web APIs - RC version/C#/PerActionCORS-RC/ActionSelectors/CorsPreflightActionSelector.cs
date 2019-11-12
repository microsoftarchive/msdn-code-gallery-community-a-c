using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using PerActionCORS_RC.Filters;

namespace PerActionCORS_RC.ActionSelectors
{
    public class CorsPreflightActionSelector : ApiControllerActionSelector
    {
        const string Origin = "Origin";
        const string AccessControlRequestMethod = "Access-Control-Request-Method";
        const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";

        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            HttpRequestMessage originalRequest = controllerContext.Request;
            bool isCorsRequest = originalRequest.Headers.Contains(Origin);

            if (originalRequest.Method == HttpMethod.Options && isCorsRequest)
            {
                string accessControlRequestMethod = originalRequest.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
                if (!string.IsNullOrEmpty(accessControlRequestMethod))
                {
                    HttpRequestMessage modifiedRequest = new HttpRequestMessage(
                        new HttpMethod(accessControlRequestMethod),
                        originalRequest.RequestUri);
                    controllerContext.Request = modifiedRequest;
                    HttpActionDescriptor actualDescriptor = base.SelectAction(controllerContext);
                    controllerContext.Request = originalRequest;

                    if (actualDescriptor != null)
                    {
                        if (actualDescriptor.GetFilters().OfType<EnableCorsAttribute>().Any())
                        {
                            return new PreflightActionDescriptor(actualDescriptor, accessControlRequestMethod);
                        }
                    }
                }
            }

            return base.SelectAction(controllerContext);
        }

        class PreflightActionDescriptor : HttpActionDescriptor
        {
            HttpActionDescriptor originalAction;
            string accessControlRequestMethod;
            private HttpActionBinding actionBinding;

            public PreflightActionDescriptor(HttpActionDescriptor originalAction, string accessControlRequestMethod)
            {
                this.originalAction = originalAction;
                this.accessControlRequestMethod = accessControlRequestMethod;
                this.actionBinding = new HttpActionBinding(this, new HttpParameterBinding[0]);
            }

            public override string ActionName
            {
                get { return this.originalAction.ActionName; }
            }

            public override Task<object> ExecuteAsync(HttpControllerContext controllerContext, IDictionary<string, object> arguments)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                // No need to add the Origin; this will be added by the action filter
                response.Headers.Add(AccessControlAllowMethods, this.accessControlRequestMethod);

                string requestedHeaders = string.Join(
                    ", ", 
                    controllerContext.Request.Headers.GetValues(AccessControlRequestHeaders));

                if (!string.IsNullOrEmpty(requestedHeaders))
                {
                    response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);
                }

                var tcs = new TaskCompletionSource<object>();
                tcs.SetResult(response);
                return tcs.Task;
            }

            public override Collection<HttpParameterDescriptor> GetParameters()
            {
                return this.originalAction.GetParameters();
            }

            public override Type ReturnType
            {
                get { return typeof(HttpResponseMessage); }
            }

            public override Collection<FilterInfo> GetFilterPipeline()
            {
                return this.originalAction.GetFilterPipeline();
            }

            public override Collection<IFilter> GetFilters()
            {
                return this.originalAction.GetFilters();
            }

            public override Collection<T> GetCustomAttributes<T>()
            {
                return this.originalAction.GetCustomAttributes<T>();
            }

            public override HttpActionBinding ActionBinding
            {
                get { return this.actionBinding; }
                set { this.actionBinding = value; }
            }
        }
    }
}