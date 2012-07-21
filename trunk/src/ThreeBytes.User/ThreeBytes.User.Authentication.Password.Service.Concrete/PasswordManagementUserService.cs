using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.Password.Data.Abstract;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Service.Abstract;

namespace ThreeBytes.User.Authentication.Password.Service.Concrete
{
    public class PasswordManagementUserService : KeyedGenericService<PasswordManagementUser>, IPasswordManagementUserService
    {
        protected new readonly IPasswordManagementUserRepository Repository;

        public PasswordManagementUserService(IPasswordManagementUserRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public PasswordManagementUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
        {
            return Repository.GetByUsernameOrEmail(userIdentifier, applicationName);
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Repository.UniqueEmail(username, applicationName);
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Repository.UniqueEmail(email, applicationName);
        }

        public bool ResetPasswordCodeMatches(Guid id, Guid code)
        {
            return Repository.ResetPasswordCodeMatches(id, code);
        }
    }
}
