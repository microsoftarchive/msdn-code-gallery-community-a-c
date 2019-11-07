#region

using System.Security.Authentication;
using System.Security.Principal;
using System.Web.Mvc;
using BTL.ContractMessages.UserManagement;
using BTL.Infrastructure;

#endregion

namespace BTL.Application.Web.Infrastructure.Controller
{
    [Authorize]
    public class AuthorizedController : BaseController
    {
        public new IPrincipal User
        {
            get
            {
                Guard.Assert(AppSecurityFacade == null, "AppSecurityFacade is null");

                var principal = base.User;
                if (principal == null)
                {
                    var identity = base.User.Identity;

                    if (HttpContext.User == null)
                        throw new AuthenticationException("You're not login to system");

                    var currentUser = HttpContext.User.Identity;

                    var userInfo = AppSecurityFacade.GetUserByUserName(currentUser.Name);

                    if (userInfo == null)
                        throw new AuthenticationException(
                            "We dont have your information in database. Make sure you register correctly!!!");

                    principal = new UserPrincipal(identity, userInfo);
                }

                return principal;
            }
        }
    }
}