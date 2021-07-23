using System.Web;
using System.Web.Optimization;

namespace HCMed_Interop
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                      "~/Content/components/typeahead.js/dist/typeahead.jquery.min.js",
                      "~/Content/components/typeahead.js/dist/bloodhound.min.js",
                      "~/Content/components/typeahead.js/dist/handlebars-v3.0.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                      "~/Content/components/datatables/media/js/jquery.dataTables.js",
                      "~/Content/components/_mod/datatables/jquery.dataTables.bootstrap.js",
                      "~/Content/components/datatables.net-select/js/dataTables.select.js",
                      "~/Content/components/_mod/datatables/jquery.dataTables.config.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                      "~/Content/components/moment/min/moment.min.js",
                      "~/Content/components/moment/locale/pt-br.js"));

            // ---------------------------------- Style ---------------------------------------------------

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
