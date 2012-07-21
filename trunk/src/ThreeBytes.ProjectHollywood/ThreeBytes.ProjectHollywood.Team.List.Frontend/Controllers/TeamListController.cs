using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.Team.List.Entities;
using ThreeBytes.ProjectHollywood.Team.List.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.List.Frontend.Controllers
{
    public class TeamListController : StatelessSessionController
    {
        private readonly ITeamListEmployeeService service;

        public TeamListController(ITeamListEmployeeService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        [HttpGet]
        public ActionResult List()
        {
            IList<TeamListEmployee> employees = service.GetAll();

            if (Request.IsAjaxRequest())
                return Json(new { Items = employees }, JsonRequestBehavior.AllowGet);

            return PartialView(new { Items = employees });
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            IList<TeamListEmployee> employees = service.GetAll();
            return Json(new { Items = employees }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(Guid id)
        {
            TeamListEmployee item = service.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
