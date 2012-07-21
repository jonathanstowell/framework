using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Profile.Management.Data.Abstract;
using ThreeBytes.User.Profile.Management.Entities;
using ThreeBytes.User.Profile.Management.Service.Abstract;

namespace ThreeBytes.User.Profile.Management.Service.Concrete
{
    public class ProfileManagementProfileService : KeyedGenericService<UserProfileManagementProfile>, IProfileManagementProfileService
    {
        protected new readonly IProfileManagementProfileRepository Repository;

        public ProfileManagementProfileService(IProfileManagementProfileRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Repository.UniqueEmail(email, applicationName);
        }
    }
}
