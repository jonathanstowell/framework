using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Email.Dispatch.View.Entities.Mappings.CacheMaps
{
    public class EmailDispatchViewEmailMessageCacheMapping : CacheItemConfigurationMap
    {
        public EmailDispatchViewEmailMessageCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(EmailDispatchViewEmailMessage))
                .SetAlias("EmailDispatchViewEmailMessage")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
