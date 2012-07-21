using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.ProjectHollywood.News.List.Entities;

namespace ThreeBytes.ProjectHollywood.News.List.Frontend.Models
{
    public class PagedNewsListNewsArticleViewModel
    {
        public IPagedResult<NewsListNewsArticle> PagedResult { get; set; }
        public IMostRecentResult<NewsListNewsArticle> MostRecentResult { get; set; }

        public PagedNewsListNewsArticleViewModel(IPagedResult<NewsListNewsArticle> pagedResult)
            : this(pagedResult, null)
        {}

        public PagedNewsListNewsArticleViewModel(IPagedResult<NewsListNewsArticle> pagedResult, IMostRecentResult<NewsListNewsArticle> mostRecentResult)
        {
            PagedResult = pagedResult;
            MostRecentResult = mostRecentResult;

            if (mostRecentResult == null)
                MostRecentResult = new MostRecentResult<NewsListNewsArticle>(new List<NewsListNewsArticle>(), pagedResult.OriginalRequestDateTime, pagedResult.OriginalRequestDateTime);
        }
    }
}
