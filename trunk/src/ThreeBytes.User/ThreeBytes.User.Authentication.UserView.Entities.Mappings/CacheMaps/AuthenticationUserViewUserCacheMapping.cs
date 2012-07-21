using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Authentication.UserView.Entities.Mappings.CacheMaps
{
    public class AuthenticationUserViewUserCacheMapping : CacheItemConfigurationMap
    {
        public AuthenticationUserViewUserCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(AuthenticationUserViewUser))
                .SetAlias("AuthenticationUserViewUser")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
