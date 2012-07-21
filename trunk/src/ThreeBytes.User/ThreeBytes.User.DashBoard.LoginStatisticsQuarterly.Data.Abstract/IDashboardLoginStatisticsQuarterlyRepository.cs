using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Entities;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Abstract
{
    public interface IDashboardLoginStatisticsQuarterlyRepository : IKeyedGenericRepository<DashboardLoginStatisticsQuarterly>
    {
        int GetThisQuartersLoginCount(string applicationName);
        int[] GetLastFourQuartersLoginCounts(string applicationName);
        bool HasUserHasLoggedInThisQuarter(Guid userId, string applicationName);
        IPagedResult<DashboardLoginStatisticsQuarterly> GetPagedQuarterLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int quarter, int year, int page = 1);
    }
}
