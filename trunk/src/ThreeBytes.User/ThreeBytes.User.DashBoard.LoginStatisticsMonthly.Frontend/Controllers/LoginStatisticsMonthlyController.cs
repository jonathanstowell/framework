using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Frontend.Models;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Service.Abstract;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class LoginStatisticsMonthlyController : StatelessSessionController
    {
        private readonly IDashboardLoginStatisticsMonthlyService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public LoginStatisticsMonthlyController(IDashboardLoginStatisticsMonthlyService service, IProvideUserConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        public ActionResult MonthlyStatistics()
        {
            LoginStatisticsViewModel model = new LoginStatisticsViewModel();

            model.CurrentStatistic = service.GetThisMonthsLoginCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetLastTwelveMonthsLoginCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
