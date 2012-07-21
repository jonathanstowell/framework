using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.User.Host.Home.Frontend.Controllers
{
    public class ErrorController : StatelessSessionController
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Roles()
        {
            return View();
        }
    }
}
