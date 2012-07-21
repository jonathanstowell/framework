using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Role.List.Entities.Mappings.CacheMaps
{
    public class RoleListRoleCacheMapping : CacheItemConfigurationMap
    {
        public RoleListRoleCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(RoleListRole))
                .SetAlias("RoleListRole")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
