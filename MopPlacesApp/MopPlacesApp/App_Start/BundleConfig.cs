using System.Web;
using System.Web.Optimization;

namespace MopPlacesApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //angular scripts
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/Angular/angular.js",
                     "~/Scripts/Angular/angular-resource.js",
                     "~/Scripts/Angular/angular-ui-router.js",              
                     "~/Scripts/App/GoogleMapModule.js",
                     "~/Scripts/App/GoogleMap/Service/GoogleMapService.js",
                     "~/Scripts/App/GoogleMap/Controller/GoogleMapController.js",
                     "~/Scripts/App/GoogleMap/Directive/GoogleMapDirective.js",
                     "~/Scripts/Angular/angular-growl.min.js",
                     "~/Scripts/jcs-auto-validate.min.js",
                     "~/Scripts/App/App.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/angular-growl.min.css"));
        }
    }
}
