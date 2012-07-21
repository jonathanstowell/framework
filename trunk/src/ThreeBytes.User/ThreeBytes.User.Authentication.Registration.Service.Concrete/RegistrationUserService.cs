using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.Registration.Data.Abstract;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;

namespace ThreeBytes.User.Authentication.Registration.Service.Concrete
{
    public class RegistrationUserService : KeyedGenericService<RegistrationUser>, IRegistrationUserService
    {
        protected new readonly IRegistrationUserRepository Repository;

        public RegistrationUserService(IRegistrationUserRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public RegistrationUser GetByUsername(string username, string applicationName)
        {
            return Repository.GetByUsername(username, applicationName);
        }

        public RegistrationUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
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

        public bool VerifyCodeMatches(Guid id, Guid verifiedCode)
        {
            return Repository.VerifyCodeMatches(id, verifiedCode);
        }
    }
}
