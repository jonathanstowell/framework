using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Email.Dispatch.List.Entities.Mappings.CacheMaps
{
    public class EmailDispatchListEmailCacheMapping : CacheItemConfigurationMap
    {
        public EmailDispatchListEmailCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(EmailDispatchListEmailMessage))
                .SetAlias("EmailDispatchListEmailMessage")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
