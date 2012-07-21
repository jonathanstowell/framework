using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Data.Concrete.Infrastructure
{
    public class DashboardRegistrationStatisticsYearlyDatabaseFactory : AbstractDatabaseFactoryBase, IDashboardRegistrationStatisticsYearlyDatabaseFactory
    {
        public DashboardRegistrationStatisticsYearlyDatabaseFactory(IProvideDashboardRegistrationStatisticsYearlySessionFactoryInitialisation provideAuthenticationSessionFactoryInitialisation)
            : base(provideAuthenticationSessionFactoryInitialisation)
        {
        }
    }
}
