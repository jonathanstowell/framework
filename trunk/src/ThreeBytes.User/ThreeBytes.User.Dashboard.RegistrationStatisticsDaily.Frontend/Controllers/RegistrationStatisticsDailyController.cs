using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Frontend.Models;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Service.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class RegistrationStatisticsDailyController : StatelessSessionController
    {
        private readonly IDashboardRegistrationStatisticsDailyService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public RegistrationStatisticsDailyController(IDashboardRegistrationStatisticsDailyService service, IProvideUserConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        public ActionResult DailyStatistic()
        {
            RegistrationStatisticViewModel model = new RegistrationStatisticViewModel();

            model.CurrentStatistic = service.GetTodaysRegistrationCount(userConfiguration.ApplicationName);

            return PartialView(model);
        }

        public ActionResult DailyStatistics()
        {
            RegistrationStatisticsViewModel model = new RegistrationStatisticsViewModel();

            model.CurrentStatistic = service.GetTodaysRegistrationCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetLastThirtyDaysRegistrationCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
