namespace MVCRegistrationActivities
{
    using System;
    using System.Web.Mvc;

    public static class UrlHelperExtensions
    {
        #region Public Methods and Operators

        public static string FullyQualifiedAction(this UrlHelper urlHelper, string actionName, string controllerName)
        {
            return FullyQualify(
                urlHelper.RequestContext.HttpContext.Request.Url, urlHelper.Action(actionName, controllerName));
        }

        public static string FullyQualifiedAction(this UrlHelper urlHelper, string actionName)
        {
            return FullyQualify(urlHelper.RequestContext.HttpContext.Request.Url, urlHelper.Action(actionName));
        }

        public static string FullyQualifiedContent(this UrlHelper urlHelper, string contentPath)
        {
            return FullyQualify(urlHelper.RequestContext.HttpContext.Request.Url, urlHelper.Content(contentPath));
        }

        #endregion

        #region Methods

        private static string FullyQualify(Uri requestUri, string uri)
        {
            return new UriBuilder(requestUri.Scheme, requestUri.Host, requestUri.Port, uri).Uri.ToString();
        }

        #endregion
    }
}