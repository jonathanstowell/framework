using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.ProjectHollywood.News.View.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.View.Entities;
using ThreeBytes.ProjectHollywood.News.View.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.News.View.Service.Concrete
{
    public class NewsViewNewsArticleService : HistoricKeyedGenericService<NewsViewNewsArticle>, INewsViewNewsArticleService
    {
        protected new readonly INewsViewNewsArticleRepository Repository;

        public NewsViewNewsArticleService(INewsViewNewsArticleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }
    }
}
