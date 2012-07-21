using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Role.Management.Entities.Mappings.CacheMaps
{
    public class RoleManagementRoleCacheMapping : CacheItemConfigurationMap
    {
        public RoleManagementRoleCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(RoleManagementRole))
                .SetAlias("RoleManagementRole")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300)
                .CacheCurrentlyViewingUsersItemsForSeconds(300);

        }
    }
}
