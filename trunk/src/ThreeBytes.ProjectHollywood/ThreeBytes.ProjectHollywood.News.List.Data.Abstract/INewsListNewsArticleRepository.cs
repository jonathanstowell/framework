using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Concrete.Enums;
using ThreeBytes.ProjectHollywood.News.List.Entities;
using ThreeBytes.ProjectHollywood.News.List.Entities.Enums;

namespace ThreeBytes.ProjectHollywood.News.List.Data.Abstract
{
    public interface INewsListNewsArticleRepository : IKeyedGenericRepository<NewsListNewsArticle>
    {
        IPagedResult<NewsListNewsArticle> GetAllPaged(int take, DateTime? originalRequestDateTime, int page = 1, NewsListOrderByProperty newsListOrderByProperty = NewsListOrderByProperty.CreationDateTime, SortBy sortBy = SortBy.Desc);
        IMostRecentResult<NewsListNewsArticle> GetLatestSince(DateTime datetime, NewsListOrderByProperty newsListOrderByProperty = NewsListOrderByProperty.CreationDateTime, SortBy sortBy = SortBy.Desc);
        bool FlushChanges();
    }
}
