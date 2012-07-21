using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Entities;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Service.Abstract;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Service.Concrete
{
    public class DashboardLoginStatisticsQuarterlyService : KeyedGenericService<DashboardLoginStatisticsQuarterly>, IDashboardLoginStatisticsQuarterlyService
    {
        protected new readonly IDashboardLoginStatisticsQuarterlyRepository Repository;

        public DashboardLoginStatisticsQuarterlyService(IDashboardLoginStatisticsQuarterlyRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetThisQuartersLoginCount(string applicationName)
        {
            return Repository.GetThisQuartersLoginCount(applicationName);
        }

        public int[] GetLastFourQuartersLoginCounts(string applicationName)
        {
            return Repository.GetLastFourQuartersLoginCounts(applicationName);
        }

        public bool HasUserHasLoggedInThisQuarter(Guid userId, string applicationName)
        {
            return Repository.HasUserHasLoggedInThisQuarter(userId, applicationName);
        }

        public IPagedResult<DashboardLoginStatisticsQuarterly> GetPagedQuarterLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int quarter, int year, int page = 1)
        {
            return Repository.GetPagedQuarterLoginsFor(take, originalRequestDateTime, applicationName, quarter, year, page);
        }
    }
}
