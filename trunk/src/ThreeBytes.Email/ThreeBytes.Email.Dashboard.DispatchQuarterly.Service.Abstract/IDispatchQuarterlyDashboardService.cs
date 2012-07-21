using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Service.Abstract
{
    public interface IDispatchQuarterlyDashboardService : IKeyedGenericService<DashboardDispatchQuarterlyEmail>
    {
        int GetThisQuartersDispatchCount(string applicationName);
        int[] GetLastFourQuartersDispatchCounts(string applicationName);
    }
}
