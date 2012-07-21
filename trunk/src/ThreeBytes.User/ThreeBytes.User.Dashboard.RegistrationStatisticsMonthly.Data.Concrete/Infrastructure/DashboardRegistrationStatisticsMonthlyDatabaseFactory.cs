using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Data.Concrete.Infrastructure
{
    public class DashboardRegistrationStatisticsMonthlyDatabaseFactory : AbstractDatabaseFactoryBase, IDashboardRegistrationStatisticsMonthlyDatabaseFactory
    {
        public DashboardRegistrationStatisticsMonthlyDatabaseFactory(IProvideDashboardRegistrationStatisticsMonthlySessionFactoryInitialisation provideAuthenticationSessionFactoryInitialisation)
            : base(provideAuthenticationSessionFactoryInitialisation)
        {
        }
    }
}
