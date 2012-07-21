using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Concrete.Infrastructure
{
    public class DashboardRegistrationStatisticsDailyDatabaseFactory : AbstractDatabaseFactoryBase, IDashboardRegistrationStatisticsDailyDatabaseFactory
    {
        public DashboardRegistrationStatisticsDailyDatabaseFactory(IProvideDashboardRegistrationStatisticsDailySessionFactoryInitialisation provideAuthenticationSessionFactoryInitialisation)
            : base(provideAuthenticationSessionFactoryInitialisation)
        {
        }
    }
}
