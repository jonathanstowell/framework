using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.UserView.Data.Abstract;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Service.Concrete
{
    public class AuthenticationUserViewUserService : HistoricKeyedGenericService<AuthenticationUserViewUser>, IAuthenticationUserViewUserService
    {
        protected new readonly IAuthenticationUserViewUserRepository Repository;

        public AuthenticationUserViewUserService(IAuthenticationUserViewUserRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
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

        public bool UniqueEmail(Guid itemId, string email, string applicationName)
        {
            return Repository.UniqueEmail(itemId, email, applicationName);
        }
    }
}
