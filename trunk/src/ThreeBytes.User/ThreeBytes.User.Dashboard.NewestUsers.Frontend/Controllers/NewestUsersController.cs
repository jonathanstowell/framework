using System;
using System.Web.Mvc;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.NewestUsers.Entities;
using ThreeBytes.User.Dashboard.NewestUsers.Service.Abstract;

namespace ThreeBytes.User.Dashboard.NewestUsers.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class NewestUsersController : StatelessSessionController
    {
        private readonly IDashboardNewestUsersService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public NewestUsersController(IDashboardNewestUsersService service, IProvideUserConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        public ActionResult MostRecent()
        {
            var ret = service.GetPagedNewestUsers(10, DateTime.Now, userConfiguration.ApplicationName);
            return PartialView(ret);
        }

        [HttpGet]
        public ActionResult GetPage(int? page, DateTime? datetime)
        {
            IPagedResult<DashboardNewestUsers> users = service.GetPagedNewestUsers(10, datetime, userConfiguration.ApplicationName, page ?? 1);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}
