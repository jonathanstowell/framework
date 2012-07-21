using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Service.Concrete
{
    public class AuthenticationUserManagementRoleService : KeyedGenericService<AuthenticationUserManagementRole>, IAuthenticationUserManagementRoleService
    {
        protected new readonly IAuthenticationUserManagementRoleRepository Repository;

        public AuthenticationUserManagementRoleService(IAuthenticationUserManagementRoleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IList<AuthenticationUserManagementRole> GetAll(string applicationName)
        {
            return Repository.GetAll(applicationName);
        }

        public AuthenticationUserManagementRole GetByName(string name)
        {
            return Repository.GetByName(name);
        }

        public bool Exists(string name, string applicationName)
        {
            return Repository.Exists(name, applicationName);
        }
    }
}
