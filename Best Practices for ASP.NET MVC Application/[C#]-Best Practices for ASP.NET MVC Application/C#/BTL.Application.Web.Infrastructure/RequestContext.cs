#region

using System.Web;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts;
using BTL.ContractMessages.UserManagement;

#endregion

namespace BTL.Application.Web.Infrastructure
{
    public class RequestContext
    {
        private const string RequestContextKey = "_btlRequestContext";
        private HttpContext _context;

        public static RequestContext CurrentContext
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Items.Contains(RequestContextKey))
                {
                    return (RequestContext) HttpContext.Current.Items[RequestContextKey];
                }

                var current = new RequestContext();
                if (HttpContext.Current != null) HttpContext.Current.Items.Add(RequestContextKey, current);
                return current;
            }
        }

        public InMemoryTokenManager TokenManager { get; set; }

        public AuthRequestType AuthenticationLoginType { get; set; }

        public UserPrincipal User
        {
            get
            {
                if (_context == null)
                {
                    _context = HttpContext.Current;
                }

                return _context.User as UserPrincipal;
            }
            set
            {
                if (_context == null)
                {
                    _context = HttpContext.Current;
                }

                _context.User = value;
            }
        }
    }
}