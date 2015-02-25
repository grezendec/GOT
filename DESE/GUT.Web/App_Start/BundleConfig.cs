using System.Web;
using System.Web.Optimization;

namespace GUT.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/jquery.gritter.css",
                "~/Content/site.css",
                "~/Content/grid.css"
                ));

            bundles.Add(new StyleBundle("~/Content/scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.blockUI.js",
                "~/Scripts/jquery.gritter.js",
                "~/Scripts/site.js"
                ));
        }
    }
}