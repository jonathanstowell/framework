using NHibernate.Tool.hbm2ddl;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.News.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.List.Tests.Shared
{
    public class NewsListInMemoryDatabaseFactory : AbstractDatabaseFactoryBase, INewsListDatabaseFactory
    {
        public NewsListInMemoryDatabaseFactory(ProvideInMemoryNewsListSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
            provideSessionFactoryInitialisation.InitialiseSessionFactory();
            SchemaExport export = new SchemaExport(provideSessionFactoryInitialisation.Configuration);
            export.Execute(true, true, false, Session.Connection, null);
        }
    }
}
