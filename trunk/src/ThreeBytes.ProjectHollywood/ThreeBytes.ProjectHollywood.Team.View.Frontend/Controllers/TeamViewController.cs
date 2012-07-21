using System;
using System.Drawing;
using System.Web.Mvc;
using ThreeBytes.Core.Extensions.Image;
using ThreeBytes.Core.Upload.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.Team.View.Entities;
using ThreeBytes.ProjectHollywood.Team.View.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.View.Frontend.Controllers
{
    public class TeamViewController : StatelessSessionController
    {
        private readonly ITeamViewEmployeeService service;
        private readonly IFileStore fileStore;

        public TeamViewController(ITeamViewEmployeeService service, IFileStore fileStore)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.fileStore = fileStore;
        }

        public ActionResult Details()
        {
            return PartialView();
        }

        [HttpGet]
        public FileResult GetProfileImage(string filename)
        {
            Image image = fileStore.GetImageFile(filename);
            return File(image.ToByteArray(), string.Format("image/{0}", image.GetFileTypeAsString()));
        }

        public ActionResult GetDetails(Guid id)
        {
            TeamViewEmployee employee = service.GetById(id);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
    }
}
