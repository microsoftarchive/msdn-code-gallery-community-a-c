#region

using System.Web.Mvc;
using BTL.Infrastructure.Wcf;
using BTL.Services.AppAuthentication.Contract;

#endregion

namespace BTL.Application.Facade.AppAuthentication
{
    public class AppAuthenticationFacade : IAppAuthenticationFacade
    {
        private readonly IAppAuthenticationService _appAuthenticationService;

        public AppAuthenticationFacade() :
            this(DependencyResolver.Current.GetService<IAppAuthenticationService>())
        {
        }

        public AppAuthenticationFacade(IAppAuthenticationService appSecurityService)
        {
            _appAuthenticationService = appSecurityService;
        }

        #region IAppAuthenticationFacade Members

        public void TestMethod()
        {
            _appAuthenticationService.TestMethod();
        }

        #endregion
    }
}