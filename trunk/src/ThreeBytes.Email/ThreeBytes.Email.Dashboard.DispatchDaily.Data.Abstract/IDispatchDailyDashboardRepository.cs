using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchDaily.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Data.Abstract
{
    public interface IDispatchDailyDashboardRepository : IKeyedGenericRepository<DashboardDispatchDailyEmail>
    {
        int GetTodaysDispatchCount(string applicationName);
        int[] GetLastThirtyDaysDispatchCounts(string applicationName);
    }
}
