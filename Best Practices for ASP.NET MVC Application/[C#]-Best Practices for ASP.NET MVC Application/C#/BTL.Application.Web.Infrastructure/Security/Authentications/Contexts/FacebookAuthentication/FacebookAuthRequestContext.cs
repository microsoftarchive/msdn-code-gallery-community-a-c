 #region

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using BTL.Application.Web.Infrastructure.Security.Authentications.Models;
using BTL.Infrastructure;
using BTL.Infrastructure.Dci;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.FacebookAuthentication
{
    /// <summary>
    /// User case: Prepare information for sign-in using facebook
    /// Input: FacebookAuthRequestProcessingParameter
    /// Output: Full path for redirect
    /// </summary>
    public class FacebookAuthRequestProcessingContext : DciContext<string, FacebookAuthRequestProcessingParameter>
    {
        private readonly IFacebookAuthRequestRole _facebookAuthRequestRole;

        public FacebookAuthRequestProcessingContext()
            : this(DependencyResolver.Current.GetService<IFacebookAuthRequestRole>())
        {
        }

        public FacebookAuthRequestProcessingContext(IFacebookAuthRequestRole facebookAuthRequestRole)
        {
            _facebookAuthRequestRole = facebookAuthRequestRole;
        }

        public override void Execute(Expression<Func<FacebookAuthRequestProcessingParameter>> expr)
        {
            var param = expr.Compile()();

            param.EnsureAllParamIsValid();

            Result = _facebookAuthRequestRole.FacebookAuthRequestProcessing(param.RequestUrl, param.RedirectPath, param.Parameters);
        }
    }

    /// <summary>
    /// User case: Executing sign-in action
    /// Input: N/A
    /// Output: FacebookUserInformation
    /// </summary>
    public class FacebookAuthRequestProcessedContext : DciContext<FacebookUserInformation, NullDciParameter>
    {
        private readonly IFacebookAuthRequestRole _facebookAuthRequestRole;

        public FacebookAuthRequestProcessedContext()
            : this(DependencyResolver.Current.GetService<IFacebookAuthRequestRole>())
        {
        }

        public FacebookAuthRequestProcessedContext(IFacebookAuthRequestRole facebookAuthRequestRole)
        {
            _facebookAuthRequestRole = facebookAuthRequestRole;
        }

        public override void Execute(Expression<Func<NullDciParameter>> expr)
        {
            _facebookAuthRequestRole.FacebookAuthRequestProcessed();

            Result = _facebookAuthRequestRole as FacebookUserInformation;
        }
    }

    /// <summary>
    /// Contain all parameter for FacebookAuthRequestProcessingContext
    /// Input: Request Url, Redirect Path, Parametters
    /// </summary>
    public class FacebookAuthRequestProcessingParameter : IDciParameter
    {
        public string RequestUrl { get; set; }

        public string RedirectPath { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        public void EnsureAllParamIsValid()
        {
            Guard.Assert(string.IsNullOrEmpty(RequestUrl), "RequestUrl is null or empty");
            Guard.Assert(string.IsNullOrEmpty(RedirectPath), "RedirectPath is null or empty");
        }
    }
}