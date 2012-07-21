using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using ThreeBytes.ProjectHollywood.News.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.List.Tests.Shared
{
    public class ProvideInMemoryNewsListSessionFactoryInitialisation : IProvideNewsListSessionFactoryInitialisation
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
                        Assembly.Load("ThreeBytes.ProjectHollywood.News.List.Entities.Mappings")))
                .ExposeConfiguration(Cfg => Configuration = Cfg)
                .BuildSessionFactory();
        }
    }
}
