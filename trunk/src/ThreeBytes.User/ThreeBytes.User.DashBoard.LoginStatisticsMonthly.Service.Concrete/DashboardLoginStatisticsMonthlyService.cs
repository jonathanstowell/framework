using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Entities;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Service.Abstract;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Service.Concrete
{
    public class DashboardLoginStatisticsMonthlyService : KeyedGenericService<DashboardLoginStatisticsMonthly>, IDashboardLoginStatisticsMonthlyService
    {
        protected new readonly IDashboardLoginStatisticsMonthlyRepository Repository;

        public DashboardLoginStatisticsMonthlyService(IDashboardLoginStatisticsMonthlyRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetThisMonthsLoginCount(string applicationName)
        {
            return Repository.GetThisMonthsLoginCount(applicationName);
        }

        public int[] GetLastTwelveMonthsLoginCounts(string applicationName)
        {
            return Repository.GetLastTwelveMonthsLoginCounts(applicationName);
        }

        public bool HasUserHasLoggedInThisMonth(Guid userId, string applicationName)
        {
            return Repository.HasUserHasLoggedInThisMonth(userId, applicationName);
        }

        public IPagedResult<DashboardLoginStatisticsMonthly> GetPagedMonthlyLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int month, int year, int page = 1)
        {
            return Repository.GetPagedMonthlyLoginsFor(take, originalRequestDateTime, applicationName, month, year, page);
        }
    }
}
