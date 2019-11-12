#region

using System;
using System.Web.Mvc;
using BTL.Infrastructure.Dci;
using DotNetOpenAuth.OAuth.ChannelElements;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.GoogleAuthentication
{
    public interface IGoogleAuthRequestProcessing : IDciRole
    {
        ActionResult PrepareAuthRequest(Uri callback, IConsumerTokenManager tokenManager);
    }

    public interface IGoogleAuthRequestProcessed : IDciRole
    {
        void ProcessAuthRequest(IConsumerTokenManager tokenManager);
    }

    public interface IGoogleAuthRequestRole : IGoogleAuthRequestProcessing, IGoogleAuthRequestProcessed
    {
    }

    public static class GoogleAuthRequestTrait
    {
        public static ActionResult GoogleAuthRequestProcessing(this IGoogleAuthRequestProcessing source, Uri callback, IConsumerTokenManager tokenManager)
        {
            return source.PrepareAuthRequest(callback, tokenManager);
        }

        public static void GoogleAuthRequestProcessed(this IGoogleAuthRequestProcessed source, IConsumerTokenManager tokenManager)
        {
            source.ProcessAuthRequest(tokenManager);
        }
    }
}