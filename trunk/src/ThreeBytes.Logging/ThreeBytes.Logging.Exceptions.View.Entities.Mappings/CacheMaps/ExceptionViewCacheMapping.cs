using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Logging.Exceptions.View.Entities.Mappings.CacheMaps
{
    public class ExceptionViewCacheMapping : CacheItemConfigurationMap
    {
        public ExceptionViewCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(ExceptionView))
                .SetAlias("ExceptionView")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
