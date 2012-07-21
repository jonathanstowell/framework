using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Data.Concrete.Infrastructure
{
    public class ProvideDispatchMonthlyDashboardSessionFactoryInitialisation : IProvideDispatchMonthlyDashboardSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Dashboard.DispatchMonthly.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
