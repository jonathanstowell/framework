using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Role.View.Entities.Mappings.CacheMaps
{
    public class RoleViewRoleCacheMapping : CacheItemConfigurationMap
    {
        public RoleViewRoleCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(RoleViewRole))
                .SetAlias("RoleViewRole")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
