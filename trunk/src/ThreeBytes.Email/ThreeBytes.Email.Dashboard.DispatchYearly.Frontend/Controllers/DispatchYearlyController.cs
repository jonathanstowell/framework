using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Configuration.Abstract;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Frontend.Models;
using ThreeBytes.Email.Dashboard.DispatchYearly.Service.Abstract;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class DispatchYearlyController : StatelessSessionController
    {
        private readonly IDispatchYearlyDashboardService service;
        private readonly IProvideEmailConfiguration userConfiguration;

        public DispatchYearlyController(IDispatchYearlyDashboardService service, IProvideEmailConfiguration userConfiguration)
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
            DispatchStatisticsViewModel model = new DispatchStatisticsViewModel();

            model.CurrentStatistic = service.GetThisYearsDispatchCount(userConfiguration.ApplicationName);
            model.HistoricStatistics = service.GetPreviousYearsDispatchCounts(userConfiguration.ApplicationName);

            return PartialView(model);
        }
    }
}
