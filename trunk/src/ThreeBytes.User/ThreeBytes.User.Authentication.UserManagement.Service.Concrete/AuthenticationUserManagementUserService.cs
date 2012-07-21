using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Service.Concrete
{
    public class AuthenticationUserManagementUserService : KeyedGenericService<AuthenticationUserManagementUser>, IAuthenticationUserManagementUserService
    {
        protected new readonly IAuthenticationUserManagementUserRepository Repository;

        public AuthenticationUserManagementUserService(IAuthenticationUserManagementUserRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Repository.UniqueUsername(username, applicationName);
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Repository.UniqueEmail(email, applicationName);
        }

        public AuthenticationUserManagementUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
        {
            return Repository.GetByUsernameOrEmail(userIdentifier, applicationName);
        }
    }
}
