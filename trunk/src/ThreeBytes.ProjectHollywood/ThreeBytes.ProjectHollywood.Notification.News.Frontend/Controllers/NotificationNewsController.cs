using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.ProjectHollywood.Notification.News.Frontend.Controllers
{
    public class NotificationNewsController : StatelessSessionController
    {
        public NotificationNewsController()
        {
        }

        public ActionResult Index()
        {
            return PartialView();
        }
    }
}
