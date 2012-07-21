using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.ProjectHollywood.Contact.Frontend.Controllers
{
    public class ContactController : StatelessSessionController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
