using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.Email.Host.Home.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class EmailHostController : StatelessSessionController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
