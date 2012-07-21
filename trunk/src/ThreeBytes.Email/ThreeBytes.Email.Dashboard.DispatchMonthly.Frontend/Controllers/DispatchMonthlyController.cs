using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Configuration.Abstract;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Frontend.Models;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Service.Abstract;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class DispatchMonthlyController : StatelessSessionController
    {
        private readonly IDispatchMonthlyDashboardService service;
        private readonly IProvideEmailConfiguration userConfiguration;

        public DispatchMonthlyController(IDispatchMonthlyDashboardService service, IProvideEmailConfiguration userConfiguration)
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
            DispatchStatisticsViewModel model = new DispatchStatisticsViewModel();

            model.CurrentStatistic = service.GetThisMonthsDispatchCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetLastTwelveMonthsDispatchCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
