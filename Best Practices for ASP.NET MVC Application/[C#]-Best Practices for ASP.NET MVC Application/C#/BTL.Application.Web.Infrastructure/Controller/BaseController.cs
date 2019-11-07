#region

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using BTL.Application.Facade.AppSecurity;
using BTL.Application.Web.Infrastructure.View;

#endregion

namespace BTL.Application.Web.Infrastructure.Controller
{
    [HandleError]
    public class BaseController : System.Web.Mvc.Controller
    {
        protected readonly IAppSecurityFacade AppSecurityFacade;

        protected BaseController()
            : this(DependencyResolver.Current.GetService<IAppSecurityFacade>())
        {
        }

        protected BaseController(IAppSecurityFacade appSecurityFacade)
        {
            AppSecurityFacade = appSecurityFacade;
        }

        public void Info(string message)
        {
            AddMessage(message, ErrorMessageType.Info);
        }

        public void Error(string message)
        {
            AddMessage(message, ErrorMessageType.Error);
        }

        private void AddMessage(string message, ErrorMessageType type)
        {
            var messages = new List<ErrorMessage>();

            if (TempData["MessageForView"] != null)
                messages = (List<ErrorMessage>) TempData["MessageForView"];

            messages.Add(new ErrorMessage {ErrorMessageType = type, Message = message});

            TempData["MessageForView"] = messages;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            // Fail if we can't do anything; app will crash.
            if (filterContext == null)
                return;

            // Get exception from filter context
            var ex = filterContext.Exception ?? new Exception("No further information exists.");

            filterContext.ExceptionHandled = true;

            var data = new ErrorViewModel
                           {
                               ErrorMessage = HttpUtility.HtmlEncode(ex.Message),
                               TheException = ex
                           };

            filterContext.Result = View("Error", data);
        }
    }
}