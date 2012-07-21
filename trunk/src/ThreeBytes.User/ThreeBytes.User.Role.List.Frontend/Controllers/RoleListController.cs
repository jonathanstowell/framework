using System;
using System.Web.Mvc;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Role.List.Entities;
using ThreeBytes.User.Role.List.Entities.Enums;
using ThreeBytes.User.Role.List.Frontend.Models;
using ThreeBytes.User.Role.List.Service.Abstract;

namespace ThreeBytes.User.Role.List.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class RoleListController : StatelessSessionController
    {
        private readonly IRoleListRoleService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public RoleListController(IRoleListRoleService service, IProvideUserConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        [HttpGet]
        public ActionResult List()
        {
            IPagedResult<RoleListRole> roles = service.GetAllPaged(10, null, userConfiguration.ApplicationName);
            return PartialView(new PagedRoleListRoleViewModel(roles));
        }

        [HttpGet]
        public ActionResult GetPage(int? page, DateTime? datetime, RoleListRoleOrderBy? orderBy, SortBy? sortBy)
        {
            IPagedResult<RoleListRole> roles = service.GetAllPaged(10, datetime, userConfiguration.ApplicationName, orderBy ?? RoleListRoleOrderBy.Name, sortBy ?? SortBy.Asc, page ?? 1);
            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNewerThan(DateTime datetime)
        {
            IMostRecentResult<RoleListRole> mostRecentRoles = service.GetLatestSince(datetime, userConfiguration.ApplicationName);
            return Json(mostRecentRoles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(Guid id)
        {
            RoleListRole item = service.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
