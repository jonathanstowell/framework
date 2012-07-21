using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Authentication.Registration.Entities.Mappings.CacheMaps
{
    public class RegistrationUserCacheMapping : CacheItemConfigurationMap
    {
        public RegistrationUserCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(RegistrationUser))
                .SetAlias("RegistrationUser")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
