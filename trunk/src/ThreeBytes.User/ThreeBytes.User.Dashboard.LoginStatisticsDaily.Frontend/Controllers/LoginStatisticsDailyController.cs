using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.LoginStatistics.Frontend.Models;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Service.Abstract;

namespace ThreeBytes.User.Dashboard.LoginStatistics.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class LoginStatisticsDailyController : StatelessSessionController
    {
        private readonly IDashboardLoginStatisticsDailyService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public LoginStatisticsDailyController(IDashboardLoginStatisticsDailyService service, IProvideUserConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        public ActionResult DailyStatistics()
        {
            LoginStatisticsViewModel model = new LoginStatisticsViewModel();

            model.CurrentStatistic = service.GetTodaysLoginCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetLastThirtyDaysLoginCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
