using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomAnnotationsWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DateTimeSample()
        {
            var model = new Models.DateTimeModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult DateTimeSample(Models.DateTimeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }

        public ActionResult ValueComparisonSample()
        {
            var model = new Models.ValueComparisonModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult ValueComparisonSample(Models.ValueComparisonModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }

        public ActionResult RequiredIfSample()
        {
            var model = new Models.RequiredIfModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult RequiredIfSample(Models.RequiredIfModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }
    }
}
