using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Entities.Mappings.CacheMaps
{
    public class ThespianViewThespianCacheMapping : CacheItemConfigurationMap
    {
        public ThespianViewThespianCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(ThespianViewThespian))
                .SetAlias("ThespianViewThespian")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
