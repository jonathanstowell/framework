using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Logging.Exceptions.Widget.Entities.Mappings.CacheMaps
{
    public class ExceptionWidgetCacheMapping : CacheItemConfigurationMap
    {
        public ExceptionWidgetCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(ExceptionWidget))
                .SetAlias("ExceptionWidget")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
