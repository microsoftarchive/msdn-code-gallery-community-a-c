#region

using System.Web;

#endregion

namespace BTL.Infrastructure.Extensions
{
    public static class HttpRequestBaseExtension
    {
        public static string GetUrlBase(this HttpRequestBase request)
        {
            if (request.Url == null)
            {
                return null;
            }

            return
                request.Url.Scheme + "://" +
                request.Url.Authority;
        }
    }
}