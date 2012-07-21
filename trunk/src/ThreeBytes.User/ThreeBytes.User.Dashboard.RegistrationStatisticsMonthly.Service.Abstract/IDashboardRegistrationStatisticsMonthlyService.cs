using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Service.Abstract
{
    public interface IDashboardRegistrationStatisticsMonthlyService : IKeyedGenericService<DashboardRegistrationStatisticsMonthly>
    {
        int GetThisMonthsRegistrationCount(string applicationName);
        int[] GetLastTwelveMonthsRegistrationCounts(string applicationName);
        IPagedResult<DashboardRegistrationStatisticsMonthly> GetPagedMonthlyRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int month, int year, int page = 1);
    }
}
