using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Dashboard.DispatchDaily.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchDaily.Entities;
using ThreeBytes.Email.Dashboard.DispatchDaily.Service.Abstract;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Service.Concrete
{
    public class DispatchDailyDashboardService : KeyedGenericService<DashboardDispatchDailyEmail>, IDispatchDailyDashboardService
    {
        protected new readonly IDispatchDailyDashboardRepository Repository;

        public DispatchDailyDashboardService(IDispatchDailyDashboardRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetTodaysDispatchCount(string applicationName)
        {
            return Repository.GetTodaysDispatchCount(applicationName);
        }

        public int[] GetLastThirtyDaysDispatchCounts(string applicationName)
        {
            return Repository.GetLastThirtyDaysDispatchCounts(applicationName);
        }
    }
}
