using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.Email.About.Frontend.Controllers
{
    public class AboutController : StatelessSessionController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
