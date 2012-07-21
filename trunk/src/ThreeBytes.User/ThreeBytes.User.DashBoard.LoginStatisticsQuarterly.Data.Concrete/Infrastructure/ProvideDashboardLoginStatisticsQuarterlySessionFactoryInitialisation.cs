using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Concrete.Infrastructure
{
    public class ProvideDashboardLoginStatisticsQuarterlySessionFactoryInitialisation : IProvideDashboardLoginStatisticsQuarterlySessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Dashboard.LoginStatisticsQuarterly.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
