using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.Login.Data.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;

namespace ThreeBytes.User.Authentication.Login.Service.Concrete
{
    public class LoginRoleService : KeyedGenericService<LoginRole>, ILoginRoleService
    {
        protected new readonly ILoginRoleRepository Repository;

        public LoginRoleService(ILoginRoleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
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
