using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.Logging.Exceptions.Host.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Admin", "LoggingAccess" })]
    public class LoggingExceptionsHostController : StatelessSessionController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
