using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;
using ThreeBytes.User.Role.Management.Entities;
using ThreeBytes.User.Role.Management.Frontend.PreCommands;
using ThreeBytes.User.Role.Management.Service.Abstract;

namespace ThreeBytes.User.Role.Management.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "RoleManagement" })]
    public class RoleManagementController : StatelessSessionController
    {
        private readonly IRoleManagementRoleService service;
        private readonly ICurrentlyViewingUserService currentlyViewingUserService;

        private readonly Func<CreateRolePreCommand> createRolePreCommandAccessor;
        private readonly Func<RenameRolePreCommand> renameRolePreCommandAccessor;

        public RoleManagementController(IRoleManagementRoleService service, ICurrentlyViewingUserService currentlyViewingUserService, Func<CreateRolePreCommand> createRolePreCommandAccessor, Func<RenameRolePreCommand> renameRolePreCommandAccessor)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.currentlyViewingUserService = currentlyViewingUserService;
            this.createRolePreCommandAccessor = createRolePreCommandAccessor;
            this.renameRolePreCommandAccessor = renameRolePreCommandAccessor;
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult Create(RoleManagementRole role)
        {
            var createRolePreCommand = createRolePreCommandAccessor();

            createRolePreCommand.Name = role.Name;

            createRolePreCommand.Execute();

            return Json(createRolePreCommand.Results);
        }

        public ActionResult Edit()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult Rename(Guid id, string name)
        {
            var renameRolePreCommand = renameRolePreCommandAccessor();

            renameRolePreCommand.Id = id;
            renameRolePreCommand.NewName = name;

            renameRolePreCommand.Execute();

            return Json(renameRolePreCommand.Results);
        }

        [HttpGet]
        public JsonResult GetNewsArticleForUpdateOrDelete(Guid id)
        {
            RoleManagementRole role = service.GetById(id);
            IList<ICurrentlyViewingUser> currentlyViewingUsers = currentlyViewingUserService.GetCurrentlyViewingUsers<RoleManagementRole>(id);
            return Json(new { Role = role, CurrentlyViewingUsers = currentlyViewingUsers }, JsonRequestBehavior.AllowGet);
        }
    }
}
