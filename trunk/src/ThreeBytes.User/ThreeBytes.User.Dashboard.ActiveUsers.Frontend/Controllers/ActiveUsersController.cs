using System;
using System.Web.Mvc;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.ActiveUsers.Entities;
using ThreeBytes.User.Dashboard.ActiveUsers.Service.Abstract;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class ActiveUsersController : StatelessSessionController
    {
        private readonly IDashboardActiveUsersService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public ActiveUsersController(IDashboardActiveUsersService service, IProvideUserConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        public ActionResult MostLoggedIn()
        {
            var ret = service.GetPagedActiveUsers(10, DateTime.Now, userConfiguration.ApplicationName, 1);
            return PartialView(ret);
        }

        [HttpGet]
        public ActionResult GetPage(int? page, DateTime? datetime)
        {
            IPagedResult<DashboardActiveUsers> users = service.GetPagedActiveUsers(10, datetime, userConfiguration.ApplicationName, page ?? 1);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}
