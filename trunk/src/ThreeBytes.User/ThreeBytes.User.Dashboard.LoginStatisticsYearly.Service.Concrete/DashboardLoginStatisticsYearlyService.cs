using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Data.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Entities;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Service.Abstract;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Service.Concrete
{
    public class DashboardLoginStatisticsYearlyService : KeyedGenericService<DashboardLoginStatisticsYearly>, IDashboardLoginStatisticsYearlyService
    {
        protected new readonly IDashboardLoginStatisticsYearlyRepository Repository;

        public DashboardLoginStatisticsYearlyService(IDashboardLoginStatisticsYearlyRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetThisYearsLoginCount(string applicationName)
        {
            return Repository.GetThisYearsLoginCount(applicationName);
        }

        public int[] GetPreviousYearsLoginCounts(string applicationName)
        {
            return Repository.GetPreviousYearsLoginCounts(applicationName);
        }

        public bool HasUserHasLoggedInThisYear(Guid userId, string applicationName)
        {
            return Repository.HasUserHasLoggedInThisYear(userId, applicationName);
        }

        public IPagedResult<DashboardLoginStatisticsYearly> GetPagedYearLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int year, int page = 1)
        {
            return Repository.GetPagedYearLoginsFor(take, originalRequestDateTime, applicationName, year, page);
        }
    }
}
