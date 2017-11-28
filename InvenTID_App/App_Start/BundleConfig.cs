using System.Web;
using System.Web.Optimization;

namespace InvenTID_App
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/app.js",
                      "~/Scripts/iziToast.js",
                      "~/Scripts/soundmanager/soundmanager2.js",
                      "~/Scripts/screenfull.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/iziToast.css",
                      "~/Content/css/todc-bootstrap.css",
                      "~/Content/css/app.css"));
            bundles.Add(new ScriptBundle("~/bundles/cryptojs").IncludeDirectory(
                "~/Scripts/cryptojs/", "*.js",true)
                );
        }
    }
}
