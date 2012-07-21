using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Service.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Service.Concrete
{
    public class DashboardRegistrationStatisticsQuarterlyService : KeyedGenericService<DashboardRegistrationStatisticsQuarterly>, IDashboardRegistrationStatisticsQuarterlyService
    {
        protected new readonly IDashboardRegistrationStatisticsQuarterlyRepository Repository;

        public DashboardRegistrationStatisticsQuarterlyService(IDashboardRegistrationStatisticsQuarterlyRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetThisQuartersRegistrationCount(string applicationName)
        {
            return Repository.GetThisQuartersRegistrationCount(applicationName);
        }

        public int[] GetLastFourQuartersRegistrationCounts(string applicationName)
        {
            return Repository.GetLastFourQuartersRegistrationCounts(applicationName);
        }

        public IPagedResult<DashboardRegistrationStatisticsQuarterly> GetPagedQuarterRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int quarter, int year, int page = 1)
        {
            return Repository.GetPagedQuarterRegistrationsFor(take, originalRequestDateTime, applicationName, quarter, year, page);
        }
    }
}
