using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Dashboard.DispatchYearly.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Data.Concrete.Infrastructure
{
    public class ProvideDispatchYearlyDashboardSessionFactoryInitialisation : IProvideDispatchYearlyDashboardSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Dashboard.DispatchYearly.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
