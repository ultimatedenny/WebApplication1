using System.Web.Mvc;
using WebApplication1.Class;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        MasterController M = new MasterController();
        AuthenticationController AU = new AuthenticationController();
        ErrorController E = new ErrorController();
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Cookies.GETUSEID()))
            {
                ViewBag.Username = Cookies.GETUSEID().ToUpper();
                ViewBag.Group = Cookies.GETBUSFUNC().ToUpper();
                ViewBag.Title = "Index";
                return View();
            }
            else
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
        public ActionResult MENU_01()
        {
            if (!string.IsNullOrEmpty(Cookies.GETUSEID()))
            {
                var data = M.IS_AUTHENTICATE("MENU_01");
                if(data.Count > 0)
                {
                    ViewBag.Username = Cookies.GETUSEID().ToUpper();
                    ViewBag.Group = Cookies.GETBUSFUNC().ToUpper();
                    ViewBag.Title = "MENU_01";
                    return View();
                }
                else
                {
                    return RedirectToAction("ERROR403", "ERROR");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
        public ActionResult MENU_02()
        {
            if (!string.IsNullOrEmpty(Cookies.GETUSEID()))
            {
                var data = M.IS_AUTHENTICATE("MENU_02");
                if (data.Count > 0)
                {
                    ViewBag.Username = Cookies.GETUSEID().ToUpper();
                    ViewBag.Group = Cookies.GETBUSFUNC().ToUpper();
                    ViewBag.Title = "MENU_02";
                    return View();
                }
                else
                {
                    return RedirectToAction("ERROR403", "ERROR");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
        public ActionResult MENU_03()
        {
            if (!string.IsNullOrEmpty(Cookies.GETUSEID()))
            {
                var data = M.IS_AUTHENTICATE("MENU_03");
                if (data.Count > 0)
                {
                    ViewBag.Username = Cookies.GETUSEID().ToUpper();
                    ViewBag.Group = Cookies.GETBUSFUNC().ToUpper();
                    ViewBag.Title = "MENU_03";
                    return View();
                }
                else
                {
                    return RedirectToAction("ERROR403", "ERROR");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
        public ActionResult MENU_04()
        {
            if (!string.IsNullOrEmpty(Cookies.GETUSEID()))
            {
                var data = M.IS_AUTHENTICATE("MENU_04");
                if (data.Count > 0)
                {
                    ViewBag.Username = Cookies.GETUSEID().ToUpper();
                    ViewBag.Group = Cookies.GETBUSFUNC().ToUpper();
                    ViewBag.Title = "MENU_04";
                    return View();
                }
                else
                {
                    return RedirectToAction("ERROR403", "ERROR");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
    }
}