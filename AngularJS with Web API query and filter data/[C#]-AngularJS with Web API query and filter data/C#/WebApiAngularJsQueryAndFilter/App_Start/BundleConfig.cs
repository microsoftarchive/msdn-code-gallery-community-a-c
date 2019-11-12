using System.Web;
using System.Web.Optimization;

namespace WebApiAngularJsQueryAndFilter
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/modernizr-*",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-messages.js",
                        "~/app/app.js",
                        "~/app/topNav.js",                        
                        "~/app/WelcomeController.js",
                        "~/app/books/bookResource.js",
                        "~/app/books/bookService.js",
                        "~/app/books/BooksController.js",
                        "~/app/books/bookSearch.js",
                        "~/app/books/bookSearchStatus.js",                       
                        "~/app/books/bookSort.js",
                        "~/app/books/bookFilter.js"                          
                        ));                        

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            //BundleTable.EnableOptimizations = true;
        }
    }
}
