using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Role.List.Data.Abstract;
using ThreeBytes.User.Role.List.Entities;
using ThreeBytes.User.Role.List.Entities.Enums;
using ThreeBytes.User.Role.List.Service.Abstract;

namespace ThreeBytes.User.Role.List.Service.Concrete
{
    public class RoleListRoleService : KeyedGenericService<RoleListRole>, IRoleListRoleService
    {
        protected new readonly IRoleListRoleRepository Repository;

        public RoleListRoleService(IRoleListRoleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IList<RoleListRole> GetAll(string applicationName)
        {
            Func<IList<RoleListRole>> getData = () => Repository.GetAll(applicationName);

            if (CacheEnabled)
                return Cache.Fetch(() => Repository.GetAll(applicationName), string.Format("{0}.NoOrder", applicationName), "NoSort");

            return getData();
        }

        public IPagedResult<RoleListRole> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, RoleListRoleOrderBy orderBy = RoleListRoleOrderBy.Name, SortBy sortBy = SortBy.Asc, int page = 1)
        {
            Func<IPagedResult<RoleListRole>> getData = () => Repository.GetAllPaged(take, originalRequestDateTime, applicationName, orderBy, sortBy, page);

            if (CacheEnabled)
                return Cache.Fetch(page, originalRequestDateTime, orderBy.ToString(), sortBy.ToString(), getData);

            return getData();
        }

        public IMostRecentResult<RoleListRole> GetLatestSince(DateTime datetime, string applicationName)
        {
            return Repository.GetLatestSince(datetime, applicationName);
        }

        public IList<RoleListRole> GetMostRecent(int take, string applicationName)
        {
            return Repository.GetMostRecent(take, applicationName);
        }

        public int Count(string applicationName)
        {
            return Repository.Count(applicationName);
        }

        public bool Exists(string name, string applicationName)
        {
            return Repository.Exists(name, applicationName);
        }
    }
}
