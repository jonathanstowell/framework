using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Frontend.Models;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Service.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class RegistrationStatisticsMonthlyController : StatelessSessionController
    {
        private readonly IDashboardRegistrationStatisticsMonthlyService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public RegistrationStatisticsMonthlyController(IDashboardRegistrationStatisticsMonthlyService service, IProvideUserConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        public ActionResult MonthlyStatistic()
        {
            RegistrationStatisticViewModel model = new RegistrationStatisticViewModel();

            model.CurrentStatistic = service.GetThisMonthsRegistrationCount(userConfiguration.ApplicationName);

            return PartialView(model);
        }

        public ActionResult MonthlyStatistics()
        {
            RegistrationStatisticsViewModel model = new RegistrationStatisticsViewModel();

            model.CurrentStatistic = service.GetThisMonthsRegistrationCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetLastTwelveMonthsRegistrationCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
