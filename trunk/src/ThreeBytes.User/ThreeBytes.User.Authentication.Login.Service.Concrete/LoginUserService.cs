using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.Login.Data.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;

namespace ThreeBytes.User.Authentication.Login.Service.Concrete
{
    public class LoginUserService : KeyedGenericService<LoginUser>, ILoginUserService
    {
        protected new readonly ILoginUserRepository Repository;

        public LoginUserService(ILoginUserRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public bool PasswordMatches(string username, string password, string applicationName)
        {
            return Repository.PasswordMatches(username, password, applicationName);
        }

        public LoginUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
        {
            return Repository.GetByUsernameOrEmail(userIdentifier, applicationName);
        }

        public bool HasRecords(string applicationName)
        {
            return Repository.HasRecords(applicationName);
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Repository.UniqueUsername(username, applicationName);
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Repository.UniqueEmail(email, applicationName);
        }
    }
}
