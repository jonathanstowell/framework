using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.ProjectHollywood.News.List.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.List.Entities;
using ThreeBytes.ProjectHollywood.News.List.Entities.Enums;
using ThreeBytes.ProjectHollywood.News.List.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.News.List.Service.Concrete
{
    public class NewsListNewsArticleService : KeyedGenericService<NewsListNewsArticle>, INewsListNewsArticleService
    {
        protected new readonly INewsListNewsArticleRepository Repository;

        public NewsListNewsArticleService(INewsListNewsArticleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IPagedResult<NewsListNewsArticle> GetAllPaged(int take, DateTime? originalRequestDateTime, int page = 1, NewsListOrderByProperty newsListOrderByProperty = NewsListOrderByProperty.CreationDateTime, SortBy sortBy = SortBy.Desc)
        {
            Func<IPagedResult<NewsListNewsArticle>> getData = () => Repository.GetAllPaged(take, originalRequestDateTime, page, newsListOrderByProperty, sortBy);

            if (CacheEnabled)
                return Cache.Fetch(page, originalRequestDateTime, newsListOrderByProperty.ToString(), sortBy.ToString(), getData);
                
            return getData();
        }

        public IMostRecentResult<NewsListNewsArticle> GetLatestSince(DateTime datetime, NewsListOrderByProperty newsListOrderByProperty = NewsListOrderByProperty.CreationDateTime, SortBy sortBy = SortBy.Desc)
        {
            return Repository.GetLatestSince(datetime, newsListOrderByProperty, sortBy);
        }
    }
}
