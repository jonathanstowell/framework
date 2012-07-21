using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Concrete.Infrastructure
{
    public class ProvideDashboardLoginStatisticsMonthlySessionFactoryInitialisation : IProvideDashboardLoginStatisticsMonthlySessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Dashboard.LoginStatisticsMonthly.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
