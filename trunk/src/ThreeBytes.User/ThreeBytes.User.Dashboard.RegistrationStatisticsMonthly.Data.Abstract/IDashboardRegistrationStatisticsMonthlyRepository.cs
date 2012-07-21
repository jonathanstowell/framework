using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Data.Abstract
{
    public interface IDashboardRegistrationStatisticsMonthlyRepository : IKeyedGenericRepository<DashboardRegistrationStatisticsMonthly>
    {
        int GetThisMonthsRegistrationCount(string applicationName);
        int[] GetLastTwelveMonthsRegistrationCounts(string applicationName);
        IPagedResult<DashboardRegistrationStatisticsMonthly> GetPagedMonthlyRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int month, int year, int page = 1);
    }
}
