using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Service.Abstract
{
    public interface IDashboardRegistrationStatisticsDailyService : IKeyedGenericService<DashboardRegistrationStatisticsDaily>
    {
        int GetTodaysRegistrationCount(string applicationName);
        int[] GetLastThirtyDaysRegistrationCounts(string applicationName);
        IPagedResult<DashboardRegistrationStatisticsDaily> GetPagedDailyRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, DateTime day, int page = 1);
    }
}
