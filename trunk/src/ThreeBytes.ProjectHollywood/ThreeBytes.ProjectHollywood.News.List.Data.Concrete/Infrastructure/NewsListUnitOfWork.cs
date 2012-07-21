using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.News.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.List.Data.Concrete.Infrastructure
{
    public class NewsListUnitOfWork : UnitOfWork, INewsListUnitOfWork
    {
        public NewsListUnitOfWork(INewsListDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
