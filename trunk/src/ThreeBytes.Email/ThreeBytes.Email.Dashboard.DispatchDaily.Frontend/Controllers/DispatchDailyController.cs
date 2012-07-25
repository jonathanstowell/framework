using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Configuration.Abstract;
using ThreeBytes.Email.Dashboard.DispatchDaily.Frontend.Models;
using ThreeBytes.Email.Dashboard.DispatchDaily.Service.Abstract;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class DispatchDailyController : StatelessSessionController
    {
        private readonly IDispatchDailyDashboardService service;
        private readonly IProvideEmailConfiguration userConfiguration;

        public DispatchDailyController(IDispatchDailyDashboardService service, IProvideEmailConfiguration userConfiguration)
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
            DispatchStatisticViewModel model = new DispatchStatisticViewModel();

            model.CurrentStatistic = service.GetTodaysDispatchCount(userConfiguration.ApplicationName);

            return PartialView(model);
        }

        public ActionResult DailyStatistics()
        {
            DispatchStatisticsViewModel model = new DispatchStatisticsViewModel();

            model.CurrentStatistic = service.GetTodaysDispatchCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetLastThirtyDaysDispatchCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
