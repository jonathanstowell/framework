using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Concrete.Infrastructure
{
    public class ProvideDashboardRegistrationStatisticsDailySessionFactoryInitialisation : IProvideDashboardRegistrationStatisticsDailySessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
