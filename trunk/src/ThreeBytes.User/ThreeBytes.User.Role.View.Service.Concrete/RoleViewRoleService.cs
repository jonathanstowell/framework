using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Role.View.Data.Abstract;
using ThreeBytes.User.Role.View.Entities;
using ThreeBytes.User.Role.View.Service.Abstract;

namespace ThreeBytes.User.Role.View.Service.Concrete
{
    public class RoleViewRoleService : HistoricKeyedGenericService<RoleViewRole>, IRoleViewRoleService
    {
        protected new readonly IRoleViewRoleRepository Repository;

        public RoleViewRoleService(IRoleViewRoleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public bool Exists(Guid itemId, string name, string applicationName)
        {
            return Repository.Exists(itemId, name, applicationName);
        }
    }
}
