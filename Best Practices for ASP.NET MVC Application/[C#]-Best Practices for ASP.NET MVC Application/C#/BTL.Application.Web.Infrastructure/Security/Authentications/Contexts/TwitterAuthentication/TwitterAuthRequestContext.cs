#region

using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using BTL.Application.Web.Infrastructure.Security.Authentications.Models;
using BTL.Infrastructure;
using BTL.Infrastructure.Dci;
using DotNetOpenAuth.ApplicationBlock;
using DotNetOpenAuth.OAuth.ChannelElements;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.TwitterAuthentication
{
    /// <summary>
    ///   User case: Prepare information for sign-in using twitter
    ///   Input: N/A
    ///   Output: Full path for redirect
    /// </summary>
    public class TwitterAuthRequestProcessingContext : DciContext<ActionResult, TwitterAuthRequestProcessingParameter>
    {
        private readonly ITwitterAuthRequestRole _twitterkAuthRequestRole;

        public TwitterAuthRequestProcessingContext()
            : this(DependencyResolver.Current.GetService<ITwitterAuthRequestRole>())
        {
        }

        public TwitterAuthRequestProcessingContext(ITwitterAuthRequestRole twitterAuthRequestRole)
        {
            _twitterkAuthRequestRole = twitterAuthRequestRole;
        }

        public override void Execute(Expression<Func<TwitterAuthRequestProcessingParameter>> expr)
        {
            var param = expr.Compile()();

            param.EnsureAllParamIsValid();

            Result = _twitterkAuthRequestRole.TwitterAuthRequestProcessing(param.CallBackLink, param.TokenManager);
        }
    }

    /// <summary>
    ///   User case: Executing sign-in action
    ///   Input: N/A
    ///   Output: TwitterUserInformation
    /// </summary>
    public class TwitterAuthRequestProcessedContext : DciContext<TwitterUserInformation, TwitterAuthRequestProcessedParameter>
    {
        private readonly ITwitterAuthRequestRole _twitterkAuthRequestRole;

        public TwitterAuthRequestProcessedContext()
            : this(DependencyResolver.Current.GetService<ITwitterAuthRequestRole>())
        {
        }

        public TwitterAuthRequestProcessedContext(ITwitterAuthRequestRole twitterAuthRequestRole)
        {
            _twitterkAuthRequestRole = twitterAuthRequestRole;
        }

        public override void Execute(Expression<Func<TwitterAuthRequestProcessedParameter>> expr)
        {
            var param = expr.Compile()();

            param.EnsureAllParamIsValid();

            _twitterkAuthRequestRole.TwitterAuthRequestProcessed(param.TokenManager);

            Result = _twitterkAuthRequestRole as TwitterUserInformation;
        }
    }

    /// <summary>
    ///   Contain all parameter for TwitterAuthRequestProcessingContext Input: CallBackLink, TokenManager
    /// </summary>
    public class TwitterAuthRequestProcessingParameter : IDciParameter
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
    /// Contain all parameter for TwitterAuthRequestProcessedContext Input: TokenManager
    /// </summary>
    public class TwitterAuthRequestProcessedParameter : IDciParameter
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