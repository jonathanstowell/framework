using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.News.View.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.View.Data.Abstract.Infrastructure;
using ThreeBytes.ProjectHollywood.News.View.Entities;

namespace ThreeBytes.ProjectHollywood.News.View.Data.Concrete
{
    public class NewsViewNewsArticleRepository : HistoricKeyedGenericRepository<NewsViewNewsArticle>, INewsViewNewsArticleRepository
    {
        public NewsViewNewsArticleRepository(INewsViewDatabaseFactory databaseFactory, INewsViewUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }
    }
}
