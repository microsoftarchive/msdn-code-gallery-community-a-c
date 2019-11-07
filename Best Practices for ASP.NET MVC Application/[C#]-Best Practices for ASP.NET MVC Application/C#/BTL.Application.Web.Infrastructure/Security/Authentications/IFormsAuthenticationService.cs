#region

using System.Web;
using BTL.ContractMessages.UserManagement;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications
{
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, object userInfo, bool createPersistentCookie);

        void SignOut();

        HttpCookie GetAuthCookie(string userName, bool createPersistentCookie);

        void SetAuthCookie(string userName, bool createPersistentCookie);
    }
}