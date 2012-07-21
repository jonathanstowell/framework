using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Entities;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Service.Abstract
{
    public interface IDashboardLoginStatisticsQuarterlyService : IKeyedGenericService<DashboardLoginStatisticsQuarterly>
    {
        int GetThisQuartersLoginCount(string applicationName);
        int[] GetLastFourQuartersLoginCounts(string applicationName);
        bool HasUserHasLoggedInThisQuarter(Guid userId, string applicationName);
        IPagedResult<DashboardLoginStatisticsQuarterly> GetPagedQuarterLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int quarter, int year, int page = 1);
    }
}
