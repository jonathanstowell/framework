using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Entities.Mappings.CacheMaps
{
    public class ThespianListThespianCacheMapping : CacheItemConfigurationMap
    {
        public ThespianListThespianCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(ThespianListThespian))
                .SetAlias("ThespianListThespian")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
