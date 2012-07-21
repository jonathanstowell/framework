using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.Email.Template.Widget.Entities.Mappings.CacheMaps
{
    public class EmailTemplateWidgetTemplateCacheMapping : CacheItemConfigurationMap
    {
        public EmailTemplateWidgetTemplateCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(EmailTemplateWidgetTemplate))
                .SetAlias("EmailTemplateWidgetTemplate")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);
        }
    }
}
