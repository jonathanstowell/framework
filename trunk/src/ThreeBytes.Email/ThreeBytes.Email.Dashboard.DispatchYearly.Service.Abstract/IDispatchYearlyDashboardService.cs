using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Dashboard.DispatchYearly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Service.Abstract
{
    public interface IDispatchYearlyDashboardService : IKeyedGenericService<DashboardDispatchYearlyEmail>
    {
        int GetThisYearsDispatchCount(string applicationName);
        int[] GetPreviousYearsDispatchCounts(string applicationName);
    }
}
