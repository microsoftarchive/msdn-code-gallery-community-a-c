using System.Web.Mvc;

namespace TodoListService.Controllers
{
    public class DiscoveryController : Controller
    {
        //
        // GET: /Discovery/

        public ActionResult Index()
        {
            string json = @"{""authorization_uri"":""https://login.windows.net/aalrttodosample.onmicrosoft.com/oauth2/authorize"",""resource_id"":""5190efe0-993d-4351-a519-44d6b16c01b4""}";
            return new HttpResponseActionResult(json);
        }
    }
}
