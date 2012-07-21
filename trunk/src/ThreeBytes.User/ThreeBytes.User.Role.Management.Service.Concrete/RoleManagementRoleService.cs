using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Role.Management.Data.Abstract;
using ThreeBytes.User.Role.Management.Entities;
using ThreeBytes.User.Role.Management.Service.Abstract;

namespace ThreeBytes.User.Role.Management.Service.Concrete
{
    public class RoleManagementRoleService : KeyedGenericService<RoleManagementRole>, IRoleManagementRoleService
    {
        protected new readonly IRoleManagementRoleRepository Repository;

        public RoleManagementRoleService(IRoleManagementRoleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public bool Exists(string name, string applicationName)
        {
            return Repository.Exists(name, applicationName);
        }
    }
}
