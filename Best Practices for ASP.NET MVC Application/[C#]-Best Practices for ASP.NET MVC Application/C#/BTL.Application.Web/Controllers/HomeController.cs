#region

using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BTL.Application.Facade.AppAuthentication;
using BTL.Application.Facade.AppSecurity;
using BTL.Application.Web.Infrastructure.Controller;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.FacebookAuthentication;
using BTL.Application.Web.Infrastructure.Themes;
using BTL.Application.Web.Models;
using BTL.Infrastructure.Cache;
using BTL.Infrastructure.Extensions;

#endregion

namespace BTL.Application.Web.Controllers
{
    public class HomeController : AuthorizedController
    {
        private const string HOME_INDEX_VIEW_MODEL = "HomeIndexViewModel";
        private readonly IAppSecurityFacade _appSecurityFacade;
        private readonly IAppAuthenticationFacade _appAuthenticationFacade;

        private readonly ICacheProvider _cacheProvider;
        private readonly IThemeProvider _themeProvider;


        public HomeController()
            : this(DependencyResolver.Current.GetService<IThemeProvider>(),
                   DependencyResolver.Current.GetService<ICacheProvider>(),
                   DependencyResolver.Current.GetService<IAppSecurityFacade>(),
                   DependencyResolver.Current.GetService<IAppAuthenticationFacade>()
                )
        {
        }

        public HomeController(IThemeProvider themeProvider, ICacheProvider cacheProvider,
                              IAppSecurityFacade appSecurityFacade, IAppAuthenticationFacade appAuthenticationFacade)
        {
            _themeProvider = themeProvider;
            _cacheProvider = cacheProvider;
            _appSecurityFacade = appSecurityFacade;
            _appAuthenticationFacade = appAuthenticationFacade;
        }

        //[UnitOfWork]
        public ActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();

            viewModel.Theme.Themes.AddRange(_themeProvider.GetThemes());

            //var result = _cacheProvider.Instance.Add(HOME_INDEX_VIEW_MODEL, viewModel);
            var aa = _appSecurityFacade.TestMethod();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeIndexViewModel viewModel)
        {
            //viewModel = _cacheProvider.Instance.Get<HomeIndexViewModel>(HOME_INDEX_VIEW_MODEL);

            if (!ModelState.IsValid)
            {
                Error("Some fields are not correct!!!");

                return RedirectToAction("Index");
            }

            TryUpdateModel(viewModel);

            return RedirectToAction("Index");
        }
    }
}