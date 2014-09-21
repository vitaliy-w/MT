using System.Web.Optimization;

namespace MT.Web.App_Start
{
    public static class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // scripts
            RegisterLibs(bundles);
            RegisterAngular(bundles);

            // styles
            RegisterCss(bundles);
        }

        private static void RegisterCss(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/styles").Include(
                "~/Content/Site.css",
                "~/Content/Mt.css",
                "~/Content/bootstrap.css"));
        }

        private static void RegisterAngular(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bundles-angular").Include(
                "~/Scripts/libs/angular.js",
                "~/Scripts/libs/angular-sanitize.js",
                "~/Scripts/application.js",
                "~/Scripts/services/*.js",
                "~/Scripts/filters/*.js",
                "~/Scripts/directives/*.js",
                "~/Scripts/controllers/*.js"));
        }

        //private static void RegisterJSON(BundleCollection bundles)
        //{
        //    bundles.Add(new ScriptBundle("~/jsScriptsbundles-json").Include(
        //                "~/Scripts/libs/json3.js"));
        //}

        private static void RegisterLibs(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bundles-libs").Include(
                "~/Scripts/libs/jquery-1.10.2.js",
                "~/Scripts/libs/jquery.validate.js",
                "~/Scripts/libs/jquery.validate.unobtrusive.js"));
        }
    }
}