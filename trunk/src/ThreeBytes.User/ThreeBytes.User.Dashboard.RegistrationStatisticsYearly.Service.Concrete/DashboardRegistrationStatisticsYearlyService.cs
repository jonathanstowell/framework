using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Entities;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Service.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Service.Concrete
{
    public class DashboardRegistrationStatisticsYearlyService : KeyedGenericService<DashboardRegistrationStatisticsYearly>, IDashboardRegistrationStatisticsYearlyService
    {
        protected new readonly IDashboardRegistrationStatisticsYearlyRepository Repository;

        public DashboardRegistrationStatisticsYearlyService(IDashboardRegistrationStatisticsYearlyRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public int GetThisYearsRegistrationCount(string applicationName)
        {
            return Repository.GetThisYearsRegistrationCount(applicationName);
        }

        public int[] GetPreviousYearsRegistrationCounts(string applicationName)
        {
            return Repository.GetPreviousYearsRegistrationCounts(applicationName);
        }

        public IPagedResult<DashboardRegistrationStatisticsYearly> GetPagedYearRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int year, int page = 1)
        {
            return Repository.GetPagedYearRegistrationsFor(take, originalRequestDateTime, applicationName, year, page);
        }
    }
}
