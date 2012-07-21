using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.News.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.View.Data.Concrete.Infrastructure
{
    public class NewsViewDatabaseFactory : AbstractDatabaseFactoryBase, INewsViewDatabaseFactory
    {
        public NewsViewDatabaseFactory(IProvideNewsViewSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
