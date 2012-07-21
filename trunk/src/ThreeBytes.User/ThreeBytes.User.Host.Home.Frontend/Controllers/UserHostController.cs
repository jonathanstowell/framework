using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.User.Host.Home.Frontend.Controllers
{
    public class UserHostController : StatelessSessionController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
