using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.ProjectHollywood.Notification.Host.Frontend.Controllers
{
    public class NotificationHostController : StatelessSessionController
    {
        public NotificationHostController()
        {
        }

        public ActionResult Index()
        {
            return PartialView();
        }
    }
}
