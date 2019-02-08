using System.Web;
using System.Web.Optimization;

namespace VideoStore
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/thirdparty/bootstrap.js",
                      "~/Scripts/thirdparty/bootbox.js",
                      "~/Scripts/thirdparty/respond.js",
                      "~/Scripts/thirdparty/DataTables/jquery.datatables.js",
                       "~/Scripts/thirdparty/typeahead.bundle.js",
                       "~/Scripts/thirdparty/toastr.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap--lumen.css",
                       "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap.css",
                       "~/Content/DataTables/css/jquery.dataTables.css",
                       "~/Content/typeahead.css",
                        "~/Content/toastr.css",
                     "~/Content/Site.css"));
        }
    }
}
