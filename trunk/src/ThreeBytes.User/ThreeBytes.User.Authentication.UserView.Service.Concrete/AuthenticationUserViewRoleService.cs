using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.UserView.Data.Abstract;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Service.Concrete
{
    public class AuthenticationUserViewRoleService : KeyedGenericService<AuthenticationUserViewRole>, IAuthenticationUserViewRoleService
    {
        protected new readonly IAuthenticationUserViewRoleRepository Repository;

        public AuthenticationUserViewRoleService(IAuthenticationUserViewRoleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
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
