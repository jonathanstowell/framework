using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Authentication.UserList.Entities.Mappings.CacheMaps
{
    public class AuthenticationUserListUserCacheMapping : CacheItemConfigurationMap
    {
        public AuthenticationUserListUserCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(AuthenticationUserListUser))
                .SetAlias("AuthenticationUserListUser")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
