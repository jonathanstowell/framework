using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Entities;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Service.Abstract;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Service.Concrete
{
    public class DispatchMonthlyDashboardService : KeyedGenericService<DashboardDispatchMonthlyEmail>, IDispatchMonthlyDashboardService
    {
        protected new readonly IDispatchMonthlyDashboardRepository Repository;

        public DispatchMonthlyDashboardService(IDispatchMonthlyDashboardRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetThisMonthsDispatchCount(string applicationName)
        {
            return Repository.GetThisMonthsDispatchCount(applicationName);
        }

        public int[] GetLastTwelveMonthsDispatchCounts(string applicationName)
        {
            return Repository.GetLastTwelveMonthsDispatchCounts(applicationName);
        }
    }
}
