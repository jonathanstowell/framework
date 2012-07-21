using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Authentication.UserManagement.Entities.Mappings.CacheMaps
{
    public class UserManagementRoleCacheMapping : CacheItemConfigurationMap
    {
        public UserManagementRoleCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(AuthenticationUserManagementRole))
                .SetAlias("AuthenticationUserManagementRole")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
