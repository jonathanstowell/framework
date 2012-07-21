using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.ProjectHollywood.News.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.List.Data.Concrete.Infrastructure
{
    public class ProvideNewsListSessionFactoryInitialisation : IProvideNewsListSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ProjectHollywoodContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.ProjectHollywood.News.List.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
