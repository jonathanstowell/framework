using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Email.Template.List.Entities.Mappings.CacheMaps
{
    public class EmailTemplateListTemplateCacheMapping : CacheItemConfigurationMap
    {
        public EmailTemplateListTemplateCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(EmailTemplateListTemplate))
                .SetAlias("EmailTemplateListTemplate")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
