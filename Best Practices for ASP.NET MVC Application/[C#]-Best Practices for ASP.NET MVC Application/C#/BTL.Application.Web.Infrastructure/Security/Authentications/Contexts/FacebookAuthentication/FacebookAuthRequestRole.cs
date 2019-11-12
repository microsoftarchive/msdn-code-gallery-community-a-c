#region

using System.Collections.Generic;
using BTL.Infrastructure.Dci;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.FacebookAuthentication
{
    public interface IFacebookAuthRequestProcessing : IDciRole
    {
        string PrepareAuthRequest(string requestUrl, string redirectPath,
                                  IDictionary<string, string> parameters = null);
    }

    public interface IFacebookAuthRequestProcessed : IDciRole
    {
        void ProcessAuthRequest();
    }

    public interface IFacebookAuthRequestRole : IFacebookAuthRequestProcessing, IFacebookAuthRequestProcessed
    {

    }

    public static class FacebookAuthRequestTrait
    {
        public static string FacebookAuthRequestProcessing(this IFacebookAuthRequestProcessing source, string requestUrl,
                                                   string redirectPath, IDictionary<string, string> parameters = null)
        {
            return source.PrepareAuthRequest(requestUrl, redirectPath, parameters);
        }

        public static void FacebookAuthRequestProcessed(this IFacebookAuthRequestProcessed source)
        {
            source.ProcessAuthRequest();
        }
    }
}