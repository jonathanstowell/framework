using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.User.Role.Host.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class RoleHostController : StatelessSessionController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
