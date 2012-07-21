using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Data.Concrete.Infrastructure
{
    public class DashboardLoginStatisticsDailyDatabaseFactory : AbstractDatabaseFactoryBase, IDashboardLoginStatisticsDailyDatabaseFactory
    {
        public DashboardLoginStatisticsDailyDatabaseFactory(IProvideDashboardLoginStatisticsDailySessionFactoryInitialisation provideAuthenticationSessionFactoryInitialisation)
            : base(provideAuthenticationSessionFactoryInitialisation)
        {
        }
    }
}
