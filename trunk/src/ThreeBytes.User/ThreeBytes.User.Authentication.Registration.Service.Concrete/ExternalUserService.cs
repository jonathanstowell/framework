using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.Registration.Data.Abstract;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;

namespace ThreeBytes.User.Authentication.Registration.Service.Concrete
{
    public class ExternalUserService : KeyedGenericService<ExternalUser>, IExternalUserService
    {
        protected new readonly IExternalUserRepository Repository;

        public ExternalUserService(IExternalUserRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public bool UserExistsByEmail(string email, string applicationName)
        {
            return Repository.UserExistsByEmail(email, applicationName);
        }

        public ExternalUser GetUserByEmail(string email, string applicationName)
        {
            return Repository.GetUserByEmail(email, applicationName);
        }
		
        public bool HasRecords(string applicationName)
        {
            return Repository.HasRecords(applicationName);
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Repository.UniqueUsername(username, applicationName);
        }
    }
}
