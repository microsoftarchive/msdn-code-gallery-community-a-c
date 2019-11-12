namespace MvcApplication1.Infrastructure
{
    using System.Web.Mvc;

    public abstract class ModelStateTempDataTransfer : ActionFilterAttribute
    {
        protected static readonly string Key = typeof(ModelStateTempDataTransfer).FullName;
    }
}