using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.ProjectHollywood.News.Host.Frontend.Controllers
{
    public class NewsHostController : StatelessSessionController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
