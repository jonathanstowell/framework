using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Role.View.Entities;
using ThreeBytes.User.Role.View.Service.Abstract;

namespace ThreeBytes.User.Role.View.FrontEnd.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class RoleViewController : StatelessSessionController
    {
        private readonly IRoleViewRoleService service;

        public RoleViewController(IRoleViewRoleService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public ActionResult Details()
        {
            return PartialView();
        }

        public JsonResult GetDetails(Guid id)
        {
            RoleViewRole role = service.GetById(id);
            return Json(role, JsonRequestBehavior.AllowGet);
        }
    }
}
