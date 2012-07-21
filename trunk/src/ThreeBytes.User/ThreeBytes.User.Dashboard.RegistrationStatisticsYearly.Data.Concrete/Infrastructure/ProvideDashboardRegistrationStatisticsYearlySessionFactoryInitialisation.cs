using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Data.Concrete.Infrastructure
{
    public class ProvideDashboardRegistrationStatisticsYearlySessionFactoryInitialisation : IProvideDashboardRegistrationStatisticsYearlySessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
