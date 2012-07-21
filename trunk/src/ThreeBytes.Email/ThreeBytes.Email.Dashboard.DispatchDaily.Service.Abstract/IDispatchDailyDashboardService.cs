using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Dashboard.DispatchDaily.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Service.Abstract
{
    public interface IDispatchDailyDashboardService : IKeyedGenericService<DashboardDispatchDailyEmail>
    {
        int GetTodaysDispatchCount(string applicationName);
        int[] GetLastThirtyDaysDispatchCounts(string applicationName);
    }
}
