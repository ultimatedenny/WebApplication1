using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/ADMINLTE/css").Include(
                      "~/Themes/ADMINLTE/dist/css/adminlte.min.css",
                      "~/Themes/ADMINLTE/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                      "~/Themes/ADMINLTE/plugins/toastr/toastr.min.css",
                      "~/Themes/ADMINLTE/plugins/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
                      "~/Themes/ADMINLTE/plugins/datatables-responsive/css/responsive.bootstrap4.min.css",
                      "~/Themes/ADMINLTE/plugins/datatables-buttons/css/buttons.bootstrap4.min.css",
                      "~/Themes/ADMINLTE/plugins/fontawesome-free/css/all.min.css"));

            bundles.Add(new Bundle("~/ADMINLTE/js").Include(
                      "~/Themes/ADMINLTE/plugins/jquery/jquery.min.js",
                      "~/Themes/ADMINLTE/plugins/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Themes/ADMINLTE/dist/js/adminlte.min.js"));
        }
    }
}
