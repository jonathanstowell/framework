using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Configuration.Abstract;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Frontend.Models;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Service.Abstract;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class DispatchQuarterlyController : StatelessSessionController
    {
        private readonly IDispatchQuarterlyDashboardService service;
        private readonly IProvideEmailConfiguration userConfiguration;

        public DispatchQuarterlyController(IDispatchQuarterlyDashboardService service, IProvideEmailConfiguration userConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.service = service;
            this.userConfiguration = userConfiguration;
        }

        public ActionResult QuarterlyStatistic()
        {
            DispatchStatisticViewModel model = new DispatchStatisticViewModel();

            model.CurrentStatistic = service.GetThisQuartersDispatchCount(userConfiguration.ApplicationName);

            return PartialView(model);
        }

        public ActionResult QuarterlyStatistics()
        {
            DispatchStatisticsViewModel model = new DispatchStatisticsViewModel();

            model.CurrentStatistic = service.GetThisQuartersDispatchCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetLastFourQuartersDispatchCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
