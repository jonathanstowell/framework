using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Dashboard.ActiveUsers.Data.Abstract;
using ThreeBytes.User.Dashboard.ActiveUsers.Entities;
using ThreeBytes.User.Dashboard.ActiveUsers.Service.Abstract;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Service.Concrete
{
    public class DashboardActiveUsersService : KeyedGenericService<DashboardActiveUsers>, IDashboardActiveUsersService
    {
        protected new readonly IDashboardActiveUsersRepository Repository;

        public DashboardActiveUsersService(IDashboardActiveUsersRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IPagedResult<DashboardActiveUsers> GetPagedActiveUsers(int take, DateTime? originalRequestDateTime, string applicationName, int page = 1)
        {
            return Repository.GetPagedActiveUsers(take, originalRequestDateTime, applicationName, page);
        }
    }
}
