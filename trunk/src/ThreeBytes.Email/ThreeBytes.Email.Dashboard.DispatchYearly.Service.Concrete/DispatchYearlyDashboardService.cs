using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Dashboard.DispatchYearly.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchYearly.Entities;
using ThreeBytes.Email.Dashboard.DispatchYearly.Service.Abstract;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Service.Concrete
{
    public class DispatchYearlyDashboardService : KeyedGenericService<DashboardDispatchYearlyEmail>, IDispatchYearlyDashboardService
    {
        protected new readonly IDispatchYearlyDashboardRepository Repository;

        public DispatchYearlyDashboardService(IDispatchYearlyDashboardRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetThisYearsDispatchCount(string applicationName)
        {
            return Repository.GetThisYearsDispatchCount(applicationName);
        }

        public int[] GetPreviousYearsDispatchCounts(string applicationName)
        {
            return Repository.GetPreviousYearsDispatchCounts(applicationName);
        }
    }
}
