using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.ProjectHollywood.Notification.Thespian.Frontend.Controllers
{
    public class NotificationThespianController : StatelessSessionController
    {
        public NotificationThespianController()
        {
        }

        public ActionResult Index()
        {
            return PartialView();
        }
    }
}
