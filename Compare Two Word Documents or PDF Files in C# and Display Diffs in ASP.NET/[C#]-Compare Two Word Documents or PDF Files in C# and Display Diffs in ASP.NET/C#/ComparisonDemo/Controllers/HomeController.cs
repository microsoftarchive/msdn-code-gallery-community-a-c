using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groupdocs.Web.UI.Comparison;

namespace ComparisonDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private const String sourceFileName = "Tables.Source.docx";
        private const String targetFileName = "Tables.Target.docx";
        private const String redlineFileName = "Redline.docx";

        public ViewResult Index()
        {
            ComparisonService service = new ComparisonService((ComparisonWidgetSettings)this.HttpContext.Application["cws"]);
            service.SourceFileName(Server.MapPath("~/App_Data/" + sourceFileName));
            service.TargetFileName(Server.MapPath("~/App_Data/" + targetFileName));
            service.ResultFileName(Server.MapPath("~/App_Data/" + redlineFileName));
            Groupdocs.Comparison.Common.ChangeInfo[] all_changes = service.Compare();

            return View(all_changes);
        }

        public ViewResult StandardGui()
        {
            using (var sourceStream = System.IO.File.OpenRead(Server.MapPath("~/App_Data/" + sourceFileName)))
            using (var targetStream = System.IO.File.OpenRead(Server.MapPath("~/App_Data/" + targetFileName)))
            {
                ComparisonSaveHandler delegate_instance = StrHandler;
                GroupdocsComparison.Comparison("#comparison-wrapper")
                    .SourceFileName(sourceFileName, sourceStream)
                    .TargetFileName(targetFileName, targetStream)
                    //.ResultFileName(redlineFileName)
                    .ImmediateCompare()
                    .ComparisonSaving += delegate_instance;

            }

            return View();
        }

        private void StrHandler(System.IO.Stream Input, out String Filename)
        {
            Filename = redlineFileName;
            //now you can save the stream to the DB or do with it what you want
            Int64 len = Input.Length;
        }
    }
}
