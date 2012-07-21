using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Data.Abstract
{
    public interface IDispatchQuarterlyDashboardRepository : IKeyedGenericRepository<DashboardDispatchQuarterlyEmail>
    {
        int GetThisQuartersDispatchCount(string applicationName);
        int[] GetLastFourQuartersDispatchCounts(string applicationName);
    }
}
