using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Frontend.Models;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Service.Abstract;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class LoginStatisticsYearlyController : StatelessSessionController
    {
        private readonly IDashboardLoginStatisticsYearlyService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public LoginStatisticsYearlyController(IDashboardLoginStatisticsYearlyService service, IProvideUserConfiguration userConfiguration)
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
            LoginStatisticsViewModel model = new LoginStatisticsViewModel();

            model.CurrentStatistic = service.GetThisYearsLoginCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetPreviousYearsLoginCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
