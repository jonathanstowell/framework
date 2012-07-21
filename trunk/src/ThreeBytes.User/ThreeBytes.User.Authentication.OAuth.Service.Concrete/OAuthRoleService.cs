using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Service.Concrete
{
    public class OAuthRoleService : KeyedGenericService<OAuthRole>, IOAuthRoleService
    {
        protected new readonly IOAuthRoleRepository Repository;

        public OAuthRoleService(IOAuthRoleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
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
