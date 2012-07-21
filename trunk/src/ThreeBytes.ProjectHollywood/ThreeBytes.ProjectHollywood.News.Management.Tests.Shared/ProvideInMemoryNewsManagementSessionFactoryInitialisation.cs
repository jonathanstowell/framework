using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using ThreeBytes.ProjectHollywood.News.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.Management.Tests.Shared
{
    public class ProvideInMemoryNewsManagementSessionFactoryInitialisation : IProvideNewsManagementSessionFactoryInitialisation
    {
        public Configuration Configuration;

        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard.InMemory().ConnectionString(
                        "Data Source=:memory:;Version=3;New=True;Pooling=True;Max Pool Size=1;"))
                .Mappings(
                    m =>
                    m.FluentMappings.AddFromAssembly(
                        Assembly.Load("ThreeBytes.ProjectHollywood.News.Management.Entities.Mappings")))
                .ExposeConfiguration(Cfg => Configuration = Cfg)
                .BuildSessionFactory();
        }
    }
}
