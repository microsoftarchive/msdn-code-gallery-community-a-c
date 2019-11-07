namespace MvcApplication1.Infrastructure
{
    using System.Web.Mvc;

    public class ExportModelStateToTempData : ModelStateTempDataTransfer
    {
        #region Public Methods and Operators

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                if ((filterContext.Result is RedirectResult) || (filterContext.Result is RedirectToRouteResult))
                {
                    filterContext.Controller.TempData[Key] = filterContext.Controller.ViewData.ModelState;
                }
            }

            base.OnActionExecuted(filterContext);
        }

        #endregion
    }
}