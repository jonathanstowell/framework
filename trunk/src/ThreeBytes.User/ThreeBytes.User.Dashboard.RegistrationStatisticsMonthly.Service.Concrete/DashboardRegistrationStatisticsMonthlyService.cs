using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Service.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Service.Concrete
{
    public class DashboardRegistrationStatisticsMonthlyService : KeyedGenericService<DashboardRegistrationStatisticsMonthly>, IDashboardRegistrationStatisticsMonthlyService
    {
        protected new readonly IDashboardRegistrationStatisticsMonthlyRepository Repository;

        public DashboardRegistrationStatisticsMonthlyService(IDashboardRegistrationStatisticsMonthlyRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetThisMonthsRegistrationCount(string applicationName)
        {
            return Repository.GetThisMonthsRegistrationCount(applicationName);
        }

        public int[] GetLastTwelveMonthsRegistrationCounts(string applicationName)
        {
            return Repository.GetLastTwelveMonthsRegistrationCounts(applicationName);
        }

        public IPagedResult<DashboardRegistrationStatisticsMonthly> GetPagedMonthlyRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int month, int year, int page = 1)
        {
            return Repository.GetPagedMonthlyRegistrationsFor(take, originalRequestDateTime, applicationName, month, year, page);
        }
    }
}
