using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Frontend.Hubs;
using ThreeBytes.User.Authentication.UserManagement.Frontend.Models;
using ThreeBytes.User.Authentication.UserManagement.Frontend.PreCommands;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserManagement" })]
    public class AuthenticationUserManagementController : StatelessSessionController
    {
        private readonly IAuthenticationUserManagementUserService service;
        private readonly IAuthenticationUserManagementRoleService roleService;
        private readonly ICurrentlyViewingUserService currentlyViewingUserService;
        private readonly IProvideUserConfiguration userConfiguration;

        private readonly Func<CreateUserRoleAssociationPreCommand> createUserRoleAssociationPreCommandAccessor;
        private readonly Func<RemoveUserRoleAssociationPreCommand> removeUserRoleAssociationPreCommandAccessor;

        public AuthenticationUserManagementController(IAuthenticationUserManagementUserService service, IAuthenticationUserManagementRoleService roleService, Func<CreateUserRoleAssociationPreCommand> createUserRoleAssociationPreCommandAccessor, IProvideUserConfiguration userConfiguration, Func<RemoveUserRoleAssociationPreCommand> removeUserRoleAssociationPreCommandAccessor, ICurrentlyViewingUserService currentlyViewingUserService)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (roleService == null)
                throw new ArgumentNullException("roleService");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.roleService = roleService;
            this.createUserRoleAssociationPreCommandAccessor = createUserRoleAssociationPreCommandAccessor;
            this.userConfiguration = userConfiguration;
            this.removeUserRoleAssociationPreCommandAccessor = removeUserRoleAssociationPreCommandAccessor;
            this.currentlyViewingUserService = currentlyViewingUserService;
        }

        [HttpGet]
        public ActionResult Manage()
        {
            IList<AuthenticationUserManagementRole> roles = roleService.GetAll(userConfiguration.ApplicationName);
            return PartialView(new UpdateUserViewModel { Roles = roles });
        }

        [HttpPost]
        public JsonResult CreateUserRoleAssociation(Guid userId, Guid roleId)
        {
            var createUserRoleAssociationPreCommand = createUserRoleAssociationPreCommandAccessor();

            createUserRoleAssociationPreCommand.UserId = userId;
            createUserRoleAssociationPreCommand.RoleId = roleId;

            createUserRoleAssociationPreCommand.Execute();

            return Json(createUserRoleAssociationPreCommand.Results);
        }

        [HttpPost]
        public JsonResult RemoveUserRoleAssociation(Guid userId, Guid roleId)
        {
            var removeUserRoleAssociationPreCommand = removeUserRoleAssociationPreCommandAccessor();

            removeUserRoleAssociationPreCommand.UserId = userId;
            removeUserRoleAssociationPreCommand.RoleId = roleId;

            removeUserRoleAssociationPreCommand.Execute();

            return Json(removeUserRoleAssociationPreCommand.Results);
        }

        [HttpGet]
        public JsonResult GetUserForUpdateOrDelete(Guid id)
        {
            AuthenticationUserManagementUser user = service.GetById(id);
            IList<ICurrentlyViewingUser> currentlyViewingUsers = currentlyViewingUserService.GetCurrentlyViewingUsers<AuthenticationUserManagementUser>(id);
            return Json(new { User = user, CurrentlyViewingUsers = currentlyViewingUsers }, JsonRequestBehavior.AllowGet);
        }
    }
}
