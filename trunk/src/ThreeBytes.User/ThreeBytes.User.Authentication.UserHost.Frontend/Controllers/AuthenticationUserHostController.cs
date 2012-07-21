using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.User.Authentication.UserHost.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class AuthenticationUserHostController : StatelessSessionController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
