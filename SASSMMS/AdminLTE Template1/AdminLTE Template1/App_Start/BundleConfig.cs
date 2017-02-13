using System.Web.Optimization;

namespace SSWebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.css")
                .Include("~/Content/css/select2.css")
                .Include("~/Content/css/datepicker3.css")
                .Include("~/Content/css/AdminLTE.css")
                .Include("~/Content/css/skins/skin-blue.css"));

            //call this bundle in the head to make sure jquery is loaded before the page
            bundles.Add(new ScriptBundle("~/Bundles/commonjs")
                .Include("~/Content/js/plugins/jquery/jquery-2.2.4.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                );

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/select2/select2.full.js")
                .Include("~/Content/js/plugins/moment/moment.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/app.js")
                .Include("~/Content/js/init.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css")
                .Include(
                        "~/Content/kendo/2015.2.902/kendo.common-bootstrap.min.css",
                        "~/Content/kendo/2015.2.902/kendo.dataviz.min.css",
                        "~/Content/kendo/2015.2.902/kendo.dataviz.default.min.css",
                        "~/Content/kendo/2015.2.902/kendo.bootstrap.min.css"));


            bundles.Add(new ScriptBundle("~/bundles/kendo")
                .Include(
                       //"~/Scripts/kendo/2015.2.902/jquery.min.js",
                       "~/Scripts/kendo/2015.2.902/kendo.all.min.js",
                       "~/Scripts/kendo/2015.2.902/kendo.aspnetmvc.min.js")
            );

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}