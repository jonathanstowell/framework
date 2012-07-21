using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Profile.View.Data.Abstract;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Service.Abstract;

namespace ThreeBytes.User.Profile.View.Service.Concrete
{
    public class ProfileViewProfileService : HistoricKeyedGenericService<UserProfileViewProfile>, IProfileViewProfileService
    {
        protected new readonly IProfileViewProfileRepository Repository;

        public ProfileViewProfileService(IProfileViewProfileRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public bool UniqueEmail(Guid itemId, string email, string applicationName)
        {
            return Repository.UniqueEmail(itemId, email, applicationName);
        }
    }
}
