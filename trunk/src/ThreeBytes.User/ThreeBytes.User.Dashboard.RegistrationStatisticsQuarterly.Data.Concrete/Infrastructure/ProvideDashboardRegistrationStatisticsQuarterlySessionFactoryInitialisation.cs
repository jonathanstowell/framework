using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Concrete.Infrastructure
{
    public class ProvideDashboardRegistrationStatisticsQuarterlySessionFactoryInitialisation : IProvideDashboardRegistrationStatisticsQuarterlySessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
