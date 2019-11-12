#region

using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL.ContractMessages.UserManagement;

#endregion

namespace BTL.Application.Web.Infrastructure.View
{
    public class ExRazorViewEngine : IViewEngine
    {
        private const string DEFAULT_THEME = "Default";

        private readonly RazorViewEngine _fallbackViewEngine = new RazorViewEngine();
        private readonly object _lock = new object();
        private RazorViewEngine _lastEngine;
        private string _lastTheme;

        #region IViewEngine Members

        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName,
                                                bool useCache)
        {
            return CreateRealViewEngine().FindPartialView(controllerContext, partialViewName, useCache);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName,
                                         bool useCache)
        {
            return CreateRealViewEngine().FindView(controllerContext, viewName, masterName, useCache);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            CreateRealViewEngine().ReleaseView(controllerContext, view);
        }

        #endregion

        private RazorViewEngine CreateRealViewEngine()
        {
            lock (_lock)
            {
                string theme;

                try
                {
                    if (HttpContext.Current.User == null)
                    {
                        theme = DEFAULT_THEME;
                    }
                    else
                    {
                        var currentUser = (UserPrincipal) HttpContext.Current.User;

                        theme = currentUser.User == null ? DEFAULT_THEME : currentUser.User.Theme;
                    }

                    if (theme == _lastTheme)
                    {
                        return _lastEngine;
                    }
                }
                catch (Exception)
                {
                    return _fallbackViewEngine;
                }

                _lastEngine = new RazorViewEngine();

                _lastEngine.PartialViewLocationFormats =
                    new[]
                        {
                            "~/Themes/" + theme + "/Views/{1}/{0}.cshtml",
                            "~/Themes/" + theme + "/Views/Shared/{0}.cshtml",
                            "~/Themes/" + theme + "/Views/Shared/{1}/{0}.cshtml",
                            "~/Themes/" + theme + "/Views/Extensions/{1}/{0}.cshtml",
                            "~/Views/Extensions/{1}/{0}.cshtml",
                        }.Union(_lastEngine.PartialViewLocationFormats).ToArray();

                _lastEngine.ViewLocationFormats =
                    new[]
                        {
                            "~/Themes/" + theme + "/Views/{1}/{0}.cshtml",
                            "~/Themes/" + theme + "/Views/Extensions/{1}/{0}.cshtml",
                            "~/Views/Extensions/{1}/{0}.cshtml",
                        }.Union(_lastEngine.ViewLocationFormats).ToArray();

                _lastEngine.MasterLocationFormats =
                    new[]
                        {
                            "~/Themes/" + theme + "/Views/{1}/{0}.cshtml",
                            "~/Themes/" + theme + "/Views/Extensions/{1}/{0}.cshtml",
                            "~/Themes/" + theme + "/Views/Shared/{1}/{0}.cshtml",
                            "~/Themes/" + theme + "/Views/Shared/{0}.cshtml",
                            "~/Views/Extensions/{1}/{0}.cshtml",
                        }.Union(_lastEngine.MasterLocationFormats).ToArray();

                _lastTheme = theme;

                return _lastEngine;
            }
        }
    }
}