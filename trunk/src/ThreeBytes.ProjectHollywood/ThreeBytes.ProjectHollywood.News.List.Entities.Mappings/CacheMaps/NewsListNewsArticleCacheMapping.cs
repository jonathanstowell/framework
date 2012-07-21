using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.ProjectHollywood.News.List.Entities.Mappings.CacheMaps
{
    public class NewsListNewsArticleCacheMapping : CacheItemConfigurationMap
    {
        public NewsListNewsArticleCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(NewsListNewsArticle))
                .SetAlias("NewsListNewsArticle")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
