using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Concrete.Infrastructure
{
    public class DashboardLoginStatisticsMonthlyDatabaseFactory : AbstractDatabaseFactoryBase, IDashboardLoginStatisticsMonthlyDatabaseFactory
    {
        public DashboardLoginStatisticsMonthlyDatabaseFactory(IProvideDashboardLoginStatisticsMonthlySessionFactoryInitialisation provideAuthenticationSessionFactoryInitialisation)
            : base(provideAuthenticationSessionFactoryInitialisation)
        {
        }
    }
}
