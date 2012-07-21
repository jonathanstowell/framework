using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Data.Concrete.Infrastructure
{
    public class ProvideDispatchQuarterlyDashboardSessionFactoryInitialisation : IProvideDispatchQuarterlyDashboardSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
