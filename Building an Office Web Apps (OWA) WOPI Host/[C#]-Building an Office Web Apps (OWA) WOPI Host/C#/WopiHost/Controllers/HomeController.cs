using MainWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Mvc;

namespace WopHost.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var testLinks = GetTestLinks();
            var model = new FileRequest
            {
                name= WebConfigurationManager.AppSettings["appSampleLink"],
                Items = testLinks
            };

            ViewBag.RootPath = Request.ApplicationPath.Length > 1 ? Request.ApplicationPath : "";

            return View(model);
        }


        public ActionResult FramedView()
        {
            var testLinks = GetTestLinks();
            var model = new FileRequest
            {
                name = WebConfigurationManager.AppSettings["appSampleLink"],
                Items = testLinks
            };

            ViewBag.RootPath = Request.ApplicationPath.Length > 1 ? Request.ApplicationPath : "";

            return View(model);
        }

        public IEnumerable<SelectListItem> GetTestLinksOld()
        {
            var section = WebConfigurationManager.GetSection("wopiHostSettings/sampleUrls") as Hashtable;
            var rv = new List<SelectListItem>();
            foreach (DictionaryEntry item in section)
            {
                rv.Add(new SelectListItem
                {
                    Selected=false,
                    Text = item.Value.ToString(),
                    Value = item.Value.ToString()
                });
            }
            return rv;
        }

        public IEnumerable<SelectListItem> GetTestLinks()
        {


            var appDataPath = HostingEnvironment.MapPath("~/App_Data/");
            var files = System.IO.Directory.GetFiles(appDataPath, "*.*")
                .Where(s => s.EndsWith(".docx") || 
                    s.EndsWith(".xlsx") || 
                    s.EndsWith(".pptx") ||
                    s.EndsWith(".pdf"));

            var rv = new List<SelectListItem>();
            foreach (string item in files)
            {
                
                rv.Add(new SelectListItem
                {
                    Selected = false,
                    Text = System.IO.Path.GetFileName(item),
                    Value = System.IO.Path.GetFileName(item)
                });
            }
            return rv;
        }




        public ActionResult Upload()
        {
            ViewBag.RootPath = Request.ApplicationPath.Length > 1 ? Request.ApplicationPath : "";

            return View();
        }

        

    }
}
