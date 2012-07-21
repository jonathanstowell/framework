using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Entities;

namespace ThreeBytes.ProjectHollywood.News.Management.Data.Abstract
{
    public interface INewsManagementNewsArticleRepository : IKeyedGenericRepository<NewsManagementNewsArticle>
    {
        bool IsNewsArticleCreatedBy(Guid id, string creator);
        bool FlushChanges();
    }
}
