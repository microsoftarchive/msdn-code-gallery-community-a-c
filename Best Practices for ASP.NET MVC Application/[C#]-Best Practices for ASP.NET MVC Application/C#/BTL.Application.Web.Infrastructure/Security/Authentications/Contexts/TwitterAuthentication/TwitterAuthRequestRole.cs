#region

using System;
using System.Web.Mvc;
using BTL.Infrastructure.Dci;
using DotNetOpenAuth.OAuth.ChannelElements;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.TwitterAuthentication
{
    public interface ITwitterAuthRequestProcessing : IDciRole
    {
        ActionResult PrepareAuthRequest(Uri callback, IConsumerTokenManager tokenManager);
    }

    public interface ITwitterAuthRequestProcessed : IDciRole
    {
        void ProcessAuthRequest(IConsumerTokenManager tokenManager);
    }

    public interface ITwitterAuthRequestRole : ITwitterAuthRequestProcessing, ITwitterAuthRequestProcessed
    {
    }

    public static class TwitterAuthRequestTrait
    {
        public static ActionResult TwitterAuthRequestProcessing(this ITwitterAuthRequestProcessing source, Uri callback, IConsumerTokenManager tokenManager)
        {
            return source.PrepareAuthRequest(callback, tokenManager);
        }

        public static void TwitterAuthRequestProcessed(this ITwitterAuthRequestProcessed source, IConsumerTokenManager tokenManager)
        {
            source.ProcessAuthRequest(tokenManager);
        }
    }
}