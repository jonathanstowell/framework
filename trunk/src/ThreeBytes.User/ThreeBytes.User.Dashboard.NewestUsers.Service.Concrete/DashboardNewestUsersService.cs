using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Dashboard.NewestUsers.Data.Abstract;
using ThreeBytes.User.Dashboard.NewestUsers.Entities;
using ThreeBytes.User.Dashboard.NewestUsers.Service.Abstract;

namespace ThreeBytes.User.Dashboard.NewestUsers.Service.Concrete
{
    public class DashboardNewestUsersService : KeyedGenericService<DashboardNewestUsers>, IDashboardNewestUsersService
    {
        protected new readonly IDashboardNewestUsersRepository Repository;

        public DashboardNewestUsersService(IDashboardNewestUsersRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IPagedResult<DashboardNewestUsers> GetPagedNewestUsers(int take, DateTime? originalRequestDateTime, string applicationName, int page = 1)
        {
            return Repository.GetPagedNewestUsers(take, originalRequestDateTime, applicationName, page);
        }
    }
}
