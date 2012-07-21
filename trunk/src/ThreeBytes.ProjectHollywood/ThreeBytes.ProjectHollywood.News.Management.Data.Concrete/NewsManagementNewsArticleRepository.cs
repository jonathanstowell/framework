using System;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.News.Management.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Data.Abstract.Infrastructure;
using ThreeBytes.ProjectHollywood.News.Management.Entities;

namespace ThreeBytes.ProjectHollywood.News.Management.Data.Concrete
{
    public class NewsManagementNewsArticleRepository : KeyedGenericRepository<NewsManagementNewsArticle>, INewsManagementNewsArticleRepository
    {
        public NewsManagementNewsArticleRepository(INewsManagementDatabaseFactory databaseFactory, INewsManagementUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public bool IsNewsArticleCreatedBy(Guid id, string creator)
        {
            return Session.QueryOver<NewsManagementNewsArticle>()
                       .Where(x => x.Id == id)
                       .And(x => x.CreatedBy == creator)
                       .RowCount() == 1;
        }
    }
}
