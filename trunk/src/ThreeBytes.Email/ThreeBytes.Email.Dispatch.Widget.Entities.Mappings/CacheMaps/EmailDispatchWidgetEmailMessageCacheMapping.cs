using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Email.Dispatch.Widget.Entities.Mappings.CacheMaps
{
    public class EmailDispatchWidgetEmailMessageCacheMapping : CacheItemConfigurationMap
    {
        public EmailDispatchWidgetEmailMessageCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(EmailDispatchWidgetEmailMessage))
                .SetAlias("EmailDispatchWidgetEmailMessage")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
