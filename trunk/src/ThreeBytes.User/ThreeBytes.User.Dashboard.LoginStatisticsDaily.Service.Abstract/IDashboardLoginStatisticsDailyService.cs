using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Service.Abstract
{
    public interface IDashboardLoginStatisticsDailyService : IKeyedGenericService<DashboardLoginStatisticsDaily>
    {
        int GetTodaysLoginCount(string applicationName);
        int[] GetLastThirtyDaysLoginCounts(string applicationName);
        bool HasUserHasLoggedInToday(Guid userId, string applicationName, DateTime date);
        IPagedResult<DashboardLoginStatisticsDaily> GetPagedDailyLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, DateTime day, int page = 1);
    }
}
