using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.News.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.View.Data.Concrete.Infrastructure
{
    public class NewsViewUnitOfWork : UnitOfWork, INewsViewUnitOfWork
    {
        public NewsViewUnitOfWork(INewsViewDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
