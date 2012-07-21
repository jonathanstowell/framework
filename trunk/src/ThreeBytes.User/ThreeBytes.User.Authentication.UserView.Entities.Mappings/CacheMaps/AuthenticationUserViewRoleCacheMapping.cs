using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Authentication.UserView.Entities.Mappings.CacheMaps
{
    public class AuthenticationUserViewRoleCacheMapping : CacheItemConfigurationMap
    {
        public AuthenticationUserViewRoleCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(AuthenticationUserViewRole))
                .SetAlias("AuthenticationUserViewRole")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
