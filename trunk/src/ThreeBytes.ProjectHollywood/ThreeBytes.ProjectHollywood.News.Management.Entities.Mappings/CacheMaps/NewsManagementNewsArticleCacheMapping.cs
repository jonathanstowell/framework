using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.ProjectHollywood.News.Management.Entities.Mappings.CacheMaps
{
    public class NewsManagementNewsArticleCacheMapping : CacheItemConfigurationMap
    {
        public NewsManagementNewsArticleCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof (NewsManagementNewsArticle))
                .SetAlias("NewsManagementArticle")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
