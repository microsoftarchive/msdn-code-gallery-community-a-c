#region

using System;
using System.Web.Mvc;
using BTL.DataAccess;

#endregion

namespace BTL.Application.Web.Infrastructure
{
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple = false, Inherited = true)]
    public class UnitOfWorkAttribute : FilterAttribute, IActionFilter
    {
        #region IActionFilter Members

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Do Nothing Sleep
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction &&
                (filterContext.Exception == null ||
                 filterContext.ExceptionHandled))
            {
                DependencyResolver.Current.GetService<UnitOfWork>().Commit();
            }
        }

        #endregion
    }
}