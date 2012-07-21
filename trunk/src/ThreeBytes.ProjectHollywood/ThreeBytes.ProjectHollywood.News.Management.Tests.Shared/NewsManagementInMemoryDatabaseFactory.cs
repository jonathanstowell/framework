using NHibernate.Tool.hbm2ddl;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.News.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.Management.Tests.Shared
{
    public class NewsManagementInMemoryDatabaseFactory : AbstractDatabaseFactoryBase, INewsManagementDatabaseFactory
    {
        public NewsManagementInMemoryDatabaseFactory(ProvideInMemoryNewsManagementSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
            provideSessionFactoryInitialisation.InitialiseSessionFactory();
            SchemaExport export = new SchemaExport(provideSessionFactoryInitialisation.Configuration);
            export.Execute(true, true, false, Session.Connection, null);
        }
    }
}
