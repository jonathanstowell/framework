using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities.Enums;
using ThreeBytes.ProjectHollywood.Thespian.List.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Frontend.Controllers
{
    public class ThespianListController : StatelessSessionController
    {
        private readonly IThespianListThespianService service;

        public ThespianListController(IThespianListThespianService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        [HttpGet]
        public ActionResult List()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult GetArtists(ThespianType type, Gender gender, bool? aToKFilter, bool? lToKFilter)
        {
            IList<ThespianListThespian> thespians = new List<ThespianListThespian>();

            if (aToKFilter == null || lToKFilter == null)
                thespians = service.GetAllThespiansOfTypeOfGender(type, gender);
            else if ((bool)aToKFilter)
                thespians = service.GetAllThespiansOfTypeOfGenderWithSurnameBetweenAK(type, gender);
            else if ((bool)lToKFilter)
                thespians = service.GetAllThespiansOfTypeOfGenderWithSurnameBetweenLZ(type, gender);

            return Json(new { Thespians = thespians }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Get(Guid id)
        {
            ThespianListThespian item = service.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
