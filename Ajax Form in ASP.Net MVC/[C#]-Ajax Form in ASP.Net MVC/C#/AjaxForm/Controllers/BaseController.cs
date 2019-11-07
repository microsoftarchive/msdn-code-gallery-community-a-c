using AjaxForm.Serialization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AjaxForm.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult NewtonSoftJsonResult(object data)
        {
            return new JsonNetResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult CreateModelStateErrors()
        {
            StringBuilder errorSummary = new StringBuilder();
            errorSummary.Append(@"<div class=""validation-summary-errors"" data-valmsg-summary=""true""><ul>");
            var errors = ModelState.Values.SelectMany(x => x.Errors);
            foreach(var error in errors)
            {
                errorSummary.Append("<li>" + error.ErrorMessage + "</li>");
            }
            errorSummary.Append("</ul></div>");
            return Content(errorSummary.ToString());
        }
	}
}