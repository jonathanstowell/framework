using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Service.Abstract
{
    public interface IDashboardRegistrationStatisticsQuarterlyService : IKeyedGenericService<DashboardRegistrationStatisticsQuarterly>
    {
        int GetThisQuartersRegistrationCount(string applicationName);
        int[] GetLastFourQuartersRegistrationCounts(string applicationName);
        IPagedResult<DashboardRegistrationStatisticsQuarterly> GetPagedQuarterRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int quarter, int year, int page = 1);
    }
}
