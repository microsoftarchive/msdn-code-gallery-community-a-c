using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class WidgetsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}