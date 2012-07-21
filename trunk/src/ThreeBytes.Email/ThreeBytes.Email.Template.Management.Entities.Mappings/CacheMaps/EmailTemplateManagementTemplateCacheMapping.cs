using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Email.Template.Management.Entities.Mappings.CacheMaps
{
    public class EmailTemplateManagementTemplateCacheMapping : CacheItemConfigurationMap
    {
        public EmailTemplateManagementTemplateCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(EmailTemplateManagementTemplate))
                .SetAlias("EmailTemplateManagementTemplate")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
