using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Service.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Service.Concrete
{
    public class DashboardRegistrationStatisticsDailyServiceService : KeyedGenericService<DashboardRegistrationStatisticsDaily>, IDashboardRegistrationStatisticsDailyService
    {
        protected new readonly IDashboardDailyRegistrationRepository Repository;

        public DashboardRegistrationStatisticsDailyServiceService(IDashboardDailyRegistrationRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetTodaysRegistrationCount(string applicationName)
        {
            return Repository.GetTodaysRegistrationCount(applicationName);
        }

        public int[] GetLastThirtyDaysRegistrationCounts(string applicationName)
        {
            return Repository.GetLastThirtyDaysRegistrationCounts(applicationName);
        }

        public IPagedResult<DashboardRegistrationStatisticsDaily> GetPagedDailyRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, DateTime day, int page = 1)
        {
            return Repository.GetPagedDailyRegistrationsFor(take, originalRequestDateTime, applicationName, day, page);
        }
    }
}
