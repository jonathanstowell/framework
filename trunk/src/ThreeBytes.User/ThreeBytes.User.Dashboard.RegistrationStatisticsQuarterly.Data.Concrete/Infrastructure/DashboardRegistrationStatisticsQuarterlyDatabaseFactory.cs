using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Concrete.Infrastructure
{
    public class DashboardRegistrationStatisticsQuarterlyDatabaseFactory : AbstractDatabaseFactoryBase, IDashboardRegistrationStatisticsQuarterlyDatabaseFactory
    {
        public DashboardRegistrationStatisticsQuarterlyDatabaseFactory(IProvideDashboardRegistrationStatisticsQuarterlySessionFactoryInitialisation provideAuthenticationSessionFactoryInitialisation)
            : base(provideAuthenticationSessionFactoryInitialisation)
        {
        }
    }
}
