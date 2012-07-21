using System;
using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.Host.Frontend.Commands;

namespace ThreeBytes.ProjectHollywood.Host.Frontend.Controllers
{
    public class HomeController : StatelessSessionController
    {
        private Func<PersistImageCommand> persistImageCommandAccessor;

        public HomeController(Func<PersistImageCommand> persistImageCommandAccessor)
        {
            this.persistImageCommandAccessor = persistImageCommandAccessor;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ImageUpload()
        {
            var cmd = persistImageCommandAccessor();

            cmd.Image = Request.Files[0];
            cmd.Execute();

            return Json(new { Result = cmd.Results, cmd.Identifier, cmd.Filename, cmd.ThumbnailName });
        }
    }
}
