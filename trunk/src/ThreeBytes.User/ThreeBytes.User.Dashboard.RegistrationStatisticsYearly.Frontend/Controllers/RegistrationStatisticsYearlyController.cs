using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Frontend.Models;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Service.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class RegistrationStatisticsYearlyController : StatelessSessionController
    {
        private readonly IDashboardRegistrationStatisticsYearlyService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public RegistrationStatisticsYearlyController(IDashboardRegistrationStatisticsYearlyService service, IProvideUserConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        public ActionResult YearlyStatistics()
        {
            RegistrationStatisticsViewModel model = new RegistrationStatisticsViewModel();

            model.CurrentStatistic = service.GetThisYearsRegistrationCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetPreviousYearsRegistrationCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
