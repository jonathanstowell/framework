using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Logging.Exceptions.List.Entities.Mappings.CacheMaps
{
    public class ExceptionListCacheMapping : CacheItemConfigurationMap
    {
        public ExceptionListCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(ExceptionList))
                .SetAlias("ExceptionList")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
