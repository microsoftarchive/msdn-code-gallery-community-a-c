using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrystalReport.Models;

namespace MvcCrystalReport.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult EmployeeListReport()
        {
            ReportViewerViewModel model = new ReportViewerViewModel();
            string content = Url.Content("~/Reports/CrystalViewer/EmployeeList.aspx");
            model.ReportPath = content;
            return View("ReportViewer", model);
        }

    }
}
