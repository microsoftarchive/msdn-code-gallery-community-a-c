namespace MvcApplication1.Infrastructure
{
    using System.Web.Mvc;

    public class ImportModelStateFromTempData : ModelStateTempDataTransfer
    {
        #region Public Methods and Operators

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var modelState = filterContext.Controller.TempData[Key] as ModelStateDictionary;

            if (modelState != null)
            {
                if (filterContext.Result is ViewResult)
                {
                    filterContext.Controller.ViewData.ModelState.Merge(modelState);
                }
                else
                {
                    filterContext.Controller.TempData.Remove(Key);
                }
            }

            base.OnActionExecuted(filterContext);
        }

        #endregion
    }
}