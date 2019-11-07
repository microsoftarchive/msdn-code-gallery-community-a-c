#region

using System.Security;
using System.Web;
using System.Web.Mvc;
using BTL.Application.Facade.AppSecurity;
using BTL.ContractMessages.UserManagement;
using BTL.Infrastructure;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.HttpModules
{
    public class FormsAuthenticationHttpModule : AuthenticationHttpModule
    {
        private readonly IAppSecurityFacade _appSecurityFacade;

        public FormsAuthenticationHttpModule()
            : this(new AppSecurityFacade())
        {
        }

        public FormsAuthenticationHttpModule(IAppSecurityFacade appSecurityFacade)
        {
            _appSecurityFacade = appSecurityFacade;
        }

        public override bool ValidateToken(string token)
        {
            Guard.MakeSureAllInstancesIsNullNot(_appSecurityFacade);

            return _appSecurityFacade.ValidateUser(token);
        }

        public override void LogOff()
        {
        }

        public override UserInfo GetUser()
        {
            if (HttpContext.Current == null)
                throw new SecurityException("You are not login to system!!!");

            return _appSecurityFacade.GetUserByUserName(HttpContext.Current.User.Identity.Name);
        }
    }
}