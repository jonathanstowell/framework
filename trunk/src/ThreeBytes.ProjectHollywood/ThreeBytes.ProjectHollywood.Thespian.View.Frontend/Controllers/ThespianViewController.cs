using System;
using System.Drawing;
using System.Web.Mvc;
using ThreeBytes.Core.Extensions.Image;
using ThreeBytes.Core.Upload.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Models;
using ThreeBytes.ProjectHollywood.Thespian.View.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Controllers
{
    public class ThespianViewController : StatelessSessionController
    {
        private readonly IThespianViewThespianService service;
        private readonly IFileStore fileStore;

        public ThespianViewController(IThespianViewThespianService service, IFileStore fileStore)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.fileStore = fileStore;
        }

        public ActionResult Details()
        {
            return PartialView(new ThespianDetailsViewModel());
        }

        public ActionResult GetDetails(Guid id)
        {
            ThespianDetailsViewModel thespian = new ThespianDetailsViewModel(service.GetById(id));
            return Json(thespian, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public FileResult GetProfileImage(string filename)
        {
            Image image = fileStore.GetImageFile(filename);
            return File(image.ToByteArray(), string.Format("image/{0}", image.GetFileTypeAsString()));
        }
    }
}
