using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Service.Abstract
{
    public interface IDispatchMonthlyDashboardService : IKeyedGenericService<DashboardDispatchMonthlyEmail>
    {
        int GetThisMonthsDispatchCount(string applicationName);
        int[] GetLastTwelveMonthsDispatchCounts(string applicationName);
    }
}
