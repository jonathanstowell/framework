using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Entities.Enums;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Service.Concrete
{
    public class OAuthUserService : KeyedGenericService<OAuthUser>, IOAuthUserService
    {
        protected new readonly IOAuthUserRepository Repository;

        public OAuthUserService(IOAuthUserRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public OAuthUser GetBy(string username, string applicationName)
        {
            return Repository.GetBy(username, applicationName);
        }

        public OAuthUser GetByEmail(string email, string applicationName)
        {
            return Repository.GetByEmail(email, applicationName);
        }

        public OAuthUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
        {
            return Repository.GetByUsernameOrEmail(userIdentifier, applicationName);
        }

        public OAuthUser GetByExternalAuthenticatorIdentifier(string identifier, ExternalAuthenticationType provider, string applicationName)
        {
            return Repository.GetByExternalAuthenticatorIdentifier(identifier, provider, applicationName);
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
