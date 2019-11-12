using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AjaxForm.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/css/bootstrap.css",
                       "~/Content/css/font-awesome.css",
                       "~/Content/css/site.css"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
               "~/Scripts/jquery-{version}.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

        }
    }
}