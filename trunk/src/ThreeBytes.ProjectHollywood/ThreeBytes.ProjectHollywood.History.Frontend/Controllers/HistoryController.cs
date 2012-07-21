using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.ProjectHollywood.History.Frontend.Controllers
{
    public class HistoryController : StatelessSessionController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
