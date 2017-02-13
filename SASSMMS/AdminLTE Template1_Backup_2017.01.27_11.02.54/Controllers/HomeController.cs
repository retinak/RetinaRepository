using System.Security.Claims;
using System.Web.Mvc;

namespace SSWebUI.Controllers
{
    public class HomeController : AppController
    {
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            ViewBag.Country = CurrentUser.Country;
            return View();
        }
    }
}