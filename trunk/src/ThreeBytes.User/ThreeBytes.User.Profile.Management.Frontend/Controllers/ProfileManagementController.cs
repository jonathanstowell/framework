using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Profile.Management.Entities;
using ThreeBytes.User.Profile.Management.Frontend.PreCommands;
using ThreeBytes.User.Profile.Management.Service.Abstract;

namespace ThreeBytes.User.Profile.Management.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess", "ProfileAccess" })]
    public class ProfileManagementController : StatelessSessionController
    {
        private readonly IProfileManagementProfileService service;
        private readonly IProvideCurrentUserDetails provideCurrentUser;

        private readonly Func<UpdateEmailAddressPreCommand> updateEmailAddressPreCommandAccessor;
        private readonly Func<UpdateProfileNamePreCommand> updateProfileNamePreCommandAccessor;

        public ProfileManagementController(IProfileManagementProfileService service, IProvideCurrentUserDetails provideCurrentUser, Func<UpdateEmailAddressPreCommand> updateEmailAddressPreCommandAccessor, Func<UpdateProfileNamePreCommand> updateProfileNamePreCommandAccessor)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (provideCurrentUser == null)
                throw new ArgumentNullException("provideCurrentUser");

            this.service = service;
            this.provideCurrentUser = provideCurrentUser;
            this.updateEmailAddressPreCommandAccessor = updateEmailAddressPreCommandAccessor;
            this.updateProfileNamePreCommandAccessor = updateProfileNamePreCommandAccessor;
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return PartialView("Edit");
        }

        [HttpPost]
        public ActionResult Rename(Guid id, string forename, string surname)
        {
            var updateProfileNamePreCommand = updateProfileNamePreCommandAccessor();

            updateProfileNamePreCommand.Id = id;
            updateProfileNamePreCommand.NewForename = forename;
            updateProfileNamePreCommand.NewSurname = surname;

            updateProfileNamePreCommand.Execute();

            return Json(updateProfileNamePreCommand.Results);
        }

        [HttpPost]
        public ActionResult UpdateEmailAddress(Guid id, string email)
        {
            var updateEmailAddressPreCommand = updateEmailAddressPreCommandAccessor();

            updateEmailAddressPreCommand.Id = id;
            updateEmailAddressPreCommand.NewEmail = email;

            updateEmailAddressPreCommand.Execute();

            return Json(updateEmailAddressPreCommand.Results);
        }

        [HttpGet]
        public ActionResult GetCurrentUserProfile()
        {
            UserProfileManagementProfile profile = service.GetById(provideCurrentUser.UserId);
            return Json(profile, JsonRequestBehavior.AllowGet);
        }
    }
}
