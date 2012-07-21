using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.News.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.Management.Data.Concrete.Infrastructure
{
    public class NewsManagementDatabaseFactory : AbstractDatabaseFactoryBase, INewsManagementDatabaseFactory
    {
        public NewsManagementDatabaseFactory(IProvideNewsManagementSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
