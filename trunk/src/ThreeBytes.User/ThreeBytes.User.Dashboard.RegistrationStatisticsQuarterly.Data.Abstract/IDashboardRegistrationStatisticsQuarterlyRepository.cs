using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Abstract
{
    public interface IDashboardRegistrationStatisticsQuarterlyRepository : IKeyedGenericRepository<DashboardRegistrationStatisticsQuarterly>
    {
        int GetThisQuartersRegistrationCount(string applicationName);
        int[] GetLastFourQuartersRegistrationCounts(string applicationName);
        IPagedResult<DashboardRegistrationStatisticsQuarterly> GetPagedQuarterRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int quarter, int year, int page = 1);
    }
}
