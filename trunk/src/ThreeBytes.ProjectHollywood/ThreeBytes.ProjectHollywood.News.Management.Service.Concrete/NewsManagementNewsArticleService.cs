using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.ProjectHollywood.News.Management.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.News.Management.Service.Concrete
{
    public class NewsManagementNewsArticleService : KeyedGenericService<NewsManagementNewsArticle>, INewsManagementNewsArticleService
    {
        protected new readonly INewsManagementNewsArticleRepository Repository;

        public NewsManagementNewsArticleService(INewsManagementNewsArticleRepository repository)
            : base(repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public NewsManagementNewsArticleService(INewsManagementNewsArticleRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public bool IsNewsArticleCreatedBy(Guid id, string creator)
        {
            return Repository.IsNewsArticleCreatedBy(id, creator);
        }
    }
}
