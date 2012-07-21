using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Email.Dispatch.Management.Entities.Mappings.CacheMaps
{
    public class EmailDispatchManagementTemplateCacheMapping : CacheItemConfigurationMap
    {
        public EmailDispatchManagementTemplateCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(EmailDispatchManagementTemplate))
                .SetAlias("EmailDispatchManagementTemplate")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
