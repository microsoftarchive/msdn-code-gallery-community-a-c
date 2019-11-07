using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OCRApp.Business_Layer;

namespace OCRApp.Controllers
{
    public class HomeController : Controller
    {
        VisionApiService obj = new VisionApiService();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ViewData["ocr"] = await obj.MakeOCRRequest();

            return View();
        }
    }
}
