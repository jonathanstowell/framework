using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Entities;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Service.Abstract
{
    public interface IDashboardLoginStatisticsMonthlyService : IKeyedGenericService<DashboardLoginStatisticsMonthly>
    {
        int GetThisMonthsLoginCount(string applicationName);
        int[] GetLastTwelveMonthsLoginCounts(string applicationName);
        bool HasUserHasLoggedInThisMonth(Guid userId, string applicationName);
        IPagedResult<DashboardLoginStatisticsMonthly> GetPagedMonthlyLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int month, int year, int page = 1);
    }
}
