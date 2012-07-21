using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class AuthenticationUserViewController : StatelessSessionController
    {
        private readonly IAuthenticationUserViewUserService service;

        public AuthenticationUserViewController(IAuthenticationUserViewUserService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public ActionResult Details(Guid? id)
        {
            return PartialView();
        }

        public JsonResult GetDetails(Guid id)
        {
            AuthenticationUserViewUser users = service.GetById(id);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}
