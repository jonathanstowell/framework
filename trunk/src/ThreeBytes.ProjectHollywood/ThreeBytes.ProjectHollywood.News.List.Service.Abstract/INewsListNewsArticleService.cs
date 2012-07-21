using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Concrete.Enums;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.List.Entities;
using ThreeBytes.ProjectHollywood.News.List.Entities.Enums;

namespace ThreeBytes.ProjectHollywood.News.List.Service.Abstract
{
    public interface INewsListNewsArticleService : IKeyedGenericService<NewsListNewsArticle>
    {
        IPagedResult<NewsListNewsArticle> GetAllPaged(int take, DateTime? originalRequestDateTime, int page = 1, NewsListOrderByProperty newsListOrderByProperty = NewsListOrderByProperty.CreationDateTime, SortBy sortBy = SortBy.Desc);
        IMostRecentResult<NewsListNewsArticle> GetLatestSince(DateTime datetime, NewsListOrderByProperty newsListOrderByProperty = NewsListOrderByProperty.CreationDateTime, SortBy sortBy = SortBy.Desc);
    }
}
