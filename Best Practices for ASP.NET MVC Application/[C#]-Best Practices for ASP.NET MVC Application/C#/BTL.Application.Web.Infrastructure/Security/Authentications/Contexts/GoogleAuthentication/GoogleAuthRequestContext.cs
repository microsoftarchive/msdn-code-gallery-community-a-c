#region

using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using BTL.Application.Web.Infrastructure.Security.Authentications.Models;
using BTL.Infrastructure;
using BTL.Infrastructure.Dci;
using DotNetOpenAuth.OAuth.ChannelElements;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.GoogleAuthentication
{
    /// <summary>
    ///   User case: Prepare information for sign-in using twitter Input: GoogleAuthRequestProcessingParameter Output: Full path for redirect
    /// </summary>
    public class GoogleAuthRequestProcessingContext : DciContext<ActionResult, GoogleAuthRequestProcessingParameter>
    {
        private readonly IGoogleAuthRequestRole _googleAuthRequestRole;

        public GoogleAuthRequestProcessingContext()
            : this(DependencyResolver.Current.GetService<IGoogleAuthRequestRole>())
        {
        }

        public GoogleAuthRequestProcessingContext(IGoogleAuthRequestRole googleAuthRequestRole)
        {
            _googleAuthRequestRole = googleAuthRequestRole;
        }

        public GoogleUserInformation AuthRequestProcessed(InMemoryTokenManager inMemoryTokenManager)
        {
            _googleAuthRequestRole.GoogleAuthRequestProcessed(inMemoryTokenManager);

            return _googleAuthRequestRole as GoogleUserInformation;
        }

        public override void Execute(Expression<Func<GoogleAuthRequestProcessingParameter>> expr)
        {
            var param = expr.Compile()();

            param.EnsureAllParamIsValid();

            Result = _googleAuthRequestRole.GoogleAuthRequestProcessing(param.CallBackLink, param.TokenManager);
        }
    }

    /// <summary>
    ///   User case: Executing sign-in action Input: N/A Output: GoogleUserInformation
    /// </summary>
    public class GoogleAuthRequestProcessedContext : DciContext<GoogleUserInformation, GoogleAuthRequestProcessedParameter>
    {
        private readonly IGoogleAuthRequestRole _googlekAuthRequestRole;

        public GoogleAuthRequestProcessedContext()
            : this(DependencyResolver.Current.GetService<IGoogleAuthRequestRole>())
        {
        }

        public GoogleAuthRequestProcessedContext(IGoogleAuthRequestRole googleAuthRequestRole)
        {
            _googlekAuthRequestRole = googleAuthRequestRole;
        }

        public override void Execute(Expression<Func<GoogleAuthRequestProcessedParameter>> expr)
        {
            var param = expr.Compile()();

            param.EnsureAllParamIsValid();

            _googlekAuthRequestRole.GoogleAuthRequestProcessed(param.TokenManager);

            Result = _googlekAuthRequestRole as GoogleUserInformation;
        }
    }

    /// <summary>
    ///   Contain all parameter for GoogleAuthRequestProcessingContext Input: CallBackLink, TokenManager
    /// </summary>
    public class GoogleAuthRequestProcessingParameter : IDciParameter
    {
        public Uri CallBackLink { get; set; }

        public IConsumerTokenManager TokenManager { get; set; }

        #region IDciParameter Members

        public void EnsureAllParamIsValid()
        {
            Guard.Assert(CallBackLink == null, "CallBackLink should not be null or empty");
            Guard.Assert(TokenManager == null, "TokenManager should not be null");
        }

        #endregion
    }

    /// <summary>
    ///   Contain all parameter for GoogleAuthRequestProcessedContext Input: TokenManager
    /// </summary>
    public class GoogleAuthRequestProcessedParameter : IDciParameter
    {
        public IConsumerTokenManager TokenManager { get; set; }

        #region IDciParameter Members

        public void EnsureAllParamIsValid()
        {
            Guard.Assert(TokenManager == null, "TokenManager should not be null");
        }

        #endregion
    }
}