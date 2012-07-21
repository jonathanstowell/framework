using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Entities;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Service.Abstract
{
    public interface IDashboardLoginStatisticsYearlyService : IKeyedGenericService<DashboardLoginStatisticsYearly>
    {
        int GetThisYearsLoginCount(string applicationName);
        int[] GetPreviousYearsLoginCounts(string applicationName);
        bool HasUserHasLoggedInThisYear(Guid userId, string applicationName);
        IPagedResult<DashboardLoginStatisticsYearly> GetPagedYearLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int year, int page = 1);
    }
}
