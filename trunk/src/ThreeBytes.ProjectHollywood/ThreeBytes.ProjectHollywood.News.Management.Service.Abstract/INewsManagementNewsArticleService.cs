using System;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Entities;

namespace ThreeBytes.ProjectHollywood.News.Management.Service.Abstract
{
    public interface INewsManagementNewsArticleService : IKeyedGenericService<NewsManagementNewsArticle>
    {
        bool IsNewsArticleCreatedBy(Guid id, string creator);
    }
}
