using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Service.Abstract;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Service.Concrete
{
    public class DispatchQuarterlyDashboardService : KeyedGenericService<DashboardDispatchQuarterlyEmail>, IDispatchQuarterlyDashboardService
    {
        protected new readonly IDispatchQuarterlyDashboardRepository Repository;

        public DispatchQuarterlyDashboardService(IDispatchQuarterlyDashboardRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetThisQuartersDispatchCount(string applicationName)
        {
            return Repository.GetThisQuartersDispatchCount(applicationName);
        }

        public int[] GetLastFourQuartersDispatchCounts(string applicationName)
        {
            return Repository.GetLastFourQuartersDispatchCounts(applicationName);
        }
    }
}
