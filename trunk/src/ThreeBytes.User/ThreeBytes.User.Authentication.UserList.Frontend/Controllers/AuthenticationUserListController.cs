using System;
using System.Web.Mvc;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Authentication.UserList.Entities;
using ThreeBytes.User.Authentication.UserList.Entities.Enums;
using ThreeBytes.User.Authentication.UserList.Frontend.Models;
using ThreeBytes.User.Authentication.UserList.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.UserList.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class AuthenticationUserListController : StatelessSessionController
    {
        private readonly IAuthenticationUserListUserService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public AuthenticationUserListController(IAuthenticationUserListUserService service, IProvideUserConfiguration userConfiguration)
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
            IPagedResult<AuthenticationUserListUser> users = service.GetAllPaged(10, null, userConfiguration.ApplicationName);
            return PartialView(new PagedUserListUserViewModel(users));
        }

        [HttpGet]
        public JsonResult GetPage(int? page, DateTime? datetime, AuthenticationUserListUserOrderBy? orderBy, SortBy? sortBy)
        {
            IPagedResult<AuthenticationUserListUser> users = service.GetAllPaged(10, datetime, userConfiguration.ApplicationName, orderBy ?? AuthenticationUserListUserOrderBy.Username, sortBy ?? SortBy.Asc, page ?? 1);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNewerThan(DateTime datetime)
        {
            IMostRecentResult<AuthenticationUserListUser> mostRecentRoles = service.GetLatestSince(datetime, userConfiguration.ApplicationName);
            return Json(mostRecentRoles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(Guid id)
        {
            AuthenticationUserListUser item = service.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
