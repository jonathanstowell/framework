using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Frontend.Models;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Service.Abstract;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "UserAccess" })]
    public class LoginStatisticsQuarterlyController : StatelessSessionController
    {
        private readonly IDashboardLoginStatisticsQuarterlyService service;
        private readonly IProvideUserConfiguration userConfiguration;

        public LoginStatisticsQuarterlyController(IDashboardLoginStatisticsQuarterlyService service, IProvideUserConfiguration userConfiguration)
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
            LoginStatisticsViewModel model = new LoginStatisticsViewModel();

            model.CurrentStatistic = service.GetThisQuartersLoginCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetLastFourQuartersLoginCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
