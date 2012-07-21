using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.ProjectHollywood.News.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.View.Data.Concrete.Infrastructure
{
    public class ProvideNewsViewSessionFactoryInitialisation : IProvideNewsViewSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ProjectHollywoodContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.ProjectHollywood.News.View.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
