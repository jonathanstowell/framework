using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Authentication.UserManagement.Entities.Mappings.CacheMaps
{
    public class UserManagementUserCacheMapping : CacheItemConfigurationMap
    {
        public UserManagementUserCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(AuthenticationUserManagementUser))
                .SetAlias("AuthenticationUserManagementUser")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
