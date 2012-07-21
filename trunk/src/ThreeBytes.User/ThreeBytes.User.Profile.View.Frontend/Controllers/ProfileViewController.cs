using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Service.Abstract;

namespace ThreeBytes.User.Profile.View.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess", "ProfileAccess" })]
    public class ProfileViewController : StatelessSessionController
    {
        private readonly IProfileViewProfileService service;
        private readonly IProvideCurrentUserDetails provideCurrentUser;

        public ProfileViewController(IProfileViewProfileService service, IProvideCurrentUserDetails provideCurrentUser)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (provideCurrentUser == null)
                throw new ArgumentNullException("provideCurrentUser");

            this.service = service;
            this.provideCurrentUser = provideCurrentUser;
        }

        public ActionResult Details()
        {
            return PartialView();
        }

        public ActionResult Links()
        {
            UserProfileViewProfile profile = service.GetById(provideCurrentUser.UserId);
            return PartialView(profile);
        }

        public ActionResult CurrentUserDetails()
        {
            UserProfileViewProfile profile = service.GetById(provideCurrentUser.UserId);
            return PartialView(profile);
        }

        public ActionResult WelcomeUser()
        {
            UserProfileViewProfile profile = service.GetById(provideCurrentUser.UserId);
            return PartialView(profile);
        }

        public JsonResult GetProfile(Guid id)
        {
            UserProfileViewProfile profile = service.GetById(id);
            return Json(profile);
        }
    }
}
