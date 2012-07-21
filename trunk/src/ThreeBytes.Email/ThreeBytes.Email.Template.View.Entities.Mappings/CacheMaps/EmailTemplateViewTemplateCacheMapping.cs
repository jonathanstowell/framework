using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Email.Template.View.Entities.Mappings.CacheMaps
{
    public class EmailTemplateViewTemplateCacheMapping : CacheItemConfigurationMap
    {
        public EmailTemplateViewTemplateCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(EmailTemplateViewTemplate))
                .SetAlias("EmailTemplateViewTemplate")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
