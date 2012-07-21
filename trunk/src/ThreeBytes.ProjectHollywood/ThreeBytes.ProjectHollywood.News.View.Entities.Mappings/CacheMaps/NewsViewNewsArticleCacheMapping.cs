using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.ProjectHollywood.News.View.Entities.Mappings.CacheMaps
{
    public class NewsViewNewsArticleCacheMapping : CacheItemConfigurationMap
    {
        public NewsViewNewsArticleCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(NewsViewNewsArticle))
                .SetAlias("NewsViewNewsArticle")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
