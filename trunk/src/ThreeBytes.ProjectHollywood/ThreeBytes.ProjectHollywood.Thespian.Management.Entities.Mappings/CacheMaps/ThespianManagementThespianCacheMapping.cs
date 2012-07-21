using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Entities.Mappings.CacheMaps
{
    public class ThespianManagementThespianCacheMapping : CacheItemConfigurationMap
    {
        public ThespianManagementThespianCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(ThespianManagementThespian))
                .SetAlias("ThespianManagementThespian")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
