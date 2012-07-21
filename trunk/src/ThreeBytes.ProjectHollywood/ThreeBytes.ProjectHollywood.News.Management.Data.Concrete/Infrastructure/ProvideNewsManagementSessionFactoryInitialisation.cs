using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.ProjectHollywood.News.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.News.Management.Data.Concrete.Infrastructure
{
    public class ProvideNewsManagementSessionFactoryInitialisation : IProvideNewsManagementSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ProjectHollywoodContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.ProjectHollywood.News.Management.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
