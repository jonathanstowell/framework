using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.ProjectHollywood.Notification.Team.Frontend.Controllers
{
    public class NotificationTeamController : StatelessSessionController
    {
        public NotificationTeamController()
        {
        }

        public ActionResult Index()
        {
            return PartialView();
        }
    }
}
