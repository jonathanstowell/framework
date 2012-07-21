using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Dashboard.LoginStatistics.Data.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Service.Abstract;

namespace ThreeBytes.User.Dashboard.LoginStatistics.Service.Concrete
{
    public class DashboardLoginStatisticsDailyServiceService : KeyedGenericService<DashboardLoginStatisticsDaily>, IDashboardLoginStatisticsDailyService
    {
        protected new readonly IDashboardDailyLoginRepository Repository;

        public DashboardLoginStatisticsDailyServiceService(IDashboardDailyLoginRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetTodaysLoginCount(string applicationName)
        {
            return Repository.GetTodaysLoginCount(applicationName);
        }

        public int[] GetLastThirtyDaysLoginCounts(string applicationName)
        {
            return Repository.GetLastThirtyDaysLoginCounts(applicationName);
        }

        public bool HasUserHasLoggedInToday(Guid userId, string applicationName, DateTime date)
        {
            return Repository.HasUserHasLoggedInToday(userId, applicationName, date);
        }

        public IPagedResult<DashboardLoginStatisticsDaily> GetPagedDailyLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, DateTime day, int page = 1)
        {
            return Repository.GetPagedDailyLoginsFor(take, originalRequestDateTime, applicationName, day, page);
        }
    }
}
