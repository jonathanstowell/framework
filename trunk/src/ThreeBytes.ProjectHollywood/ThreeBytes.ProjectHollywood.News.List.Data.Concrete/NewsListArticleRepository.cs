using System;
using NHibernate;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Core.Entities.Concrete.Enums;
using ThreeBytes.ProjectHollywood.News.List.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.List.Data.Abstract.Infrastructure;
using ThreeBytes.ProjectHollywood.News.List.Entities;
using ThreeBytes.ProjectHollywood.News.List.Entities.Enums;

namespace ThreeBytes.ProjectHollywood.News.List.Data.Concrete
{
    public class NewsListArticleRepository : KeyedGenericRepository<NewsListNewsArticle>, INewsListNewsArticleRepository
    {
        public NewsListArticleRepository(INewsListDatabaseFactory databaseFactory, INewsListUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public IPagedResult<NewsListNewsArticle> GetAllPaged(int take, DateTime? originalRequestDateTime, int page = 1, NewsListOrderByProperty newsListOrderByProperty = NewsListOrderByProperty.CreationDateTime, SortBy sortBy = SortBy.Desc)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IQueryOver<NewsListNewsArticle, NewsListNewsArticle> newsArticlesQuery = Session.QueryOver<NewsListNewsArticle>()
                .Where(x => x.CreationDateTime <= originalRequest);

            switch (newsListOrderByProperty)
            {
                default:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            newsArticlesQuery = newsArticlesQuery.OrderBy(x => x.CreationDateTime).Asc;
                            break;
                        case SortBy.Desc:
                            newsArticlesQuery = newsArticlesQuery.OrderBy(x => x.CreationDateTime).Desc;
                            break;
                    }
                    break;
            }

            newsArticlesQuery.Skip(firstResult).Take(take);

            int recordsInThisQuery = Session.QueryOver<NewsListNewsArticle>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .RowCount();

            return new PagedResult<NewsListNewsArticle>(newsArticlesQuery.List(), originalRequest, recordsInThisQuery, page, take);
        }

        public IMostRecentResult<NewsListNewsArticle> GetLatestSince(DateTime datetime, NewsListOrderByProperty newsListOrderByProperty = NewsListOrderByProperty.CreationDateTime, SortBy sortBy = SortBy.Desc)
        {
            DateTime now = DateTime.Now;

            IQueryOver<NewsListNewsArticle, NewsListNewsArticle> latestQuery = Session.QueryOver<NewsListNewsArticle>()
                .Where(x => x.CreationDateTime > datetime);

            switch (newsListOrderByProperty)
            {
                default:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            latestQuery = latestQuery.OrderBy(x => x.CreationDateTime).Asc;
                            break;
                        case SortBy.Desc:
                            latestQuery = latestQuery.OrderBy(x => x.CreationDateTime).Desc;
                            break;
                    }
                    break;
            }

            return new MostRecentResult<NewsListNewsArticle>(latestQuery.List(), datetime, now);
        }
    }
}
