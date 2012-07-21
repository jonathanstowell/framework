using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Frontend.Models;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Service.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class RegistrationStatisticsQuarterlyController : StatelessSessionController
    {
        private readonly IDashboardRegistrationStatisticsQuarterlyService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public RegistrationStatisticsQuarterlyController(IDashboardRegistrationStatisticsQuarterlyService service, IProvideUserConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        public ActionResult QuarterlyStatistics()
        {
            RegistrationStatisticsViewModel model = new RegistrationStatisticsViewModel();

            model.CurrentStatistic = service.GetThisQuartersRegistrationCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetLastFourQuartersRegistrationCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
