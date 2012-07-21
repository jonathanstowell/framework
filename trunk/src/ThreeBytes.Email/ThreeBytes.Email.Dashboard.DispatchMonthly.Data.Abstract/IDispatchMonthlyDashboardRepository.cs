using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Data.Abstract
{
    public interface IDispatchMonthlyDashboardRepository : IKeyedGenericRepository<DashboardDispatchMonthlyEmail>
    {
        int GetThisMonthsDispatchCount(string applicationName);
        int[] GetLastTwelveMonthsDispatchCounts(string applicationName);
    }
}
