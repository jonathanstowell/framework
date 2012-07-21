using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchYearly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Data.Abstract
{
    public interface IDispatchYearlyDashboardRepository : IKeyedGenericRepository<DashboardDispatchYearlyEmail>
    {
        int GetThisYearsDispatchCount(string applicationName);
        int[] GetPreviousYearsDispatchCounts(string applicationName);
    }
}
