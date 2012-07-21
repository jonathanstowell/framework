using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.User.Profile.Host.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess", "ProfileAccess" })]
    public class ProfileHostController : StatelessSessionController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
