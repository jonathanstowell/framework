using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Concrete.Infrastructure
{
    public class DashboardLoginStatisticsQuarterlyDatabaseFactory : AbstractDatabaseFactoryBase, IDashboardLoginStatisticsQuarterlyDatabaseFactory
    {
        public DashboardLoginStatisticsQuarterlyDatabaseFactory(IProvideDashboardLoginStatisticsQuarterlySessionFactoryInitialisation provideAuthenticationSessionFactoryInitialisation)
            : base(provideAuthenticationSessionFactoryInitialisation)
        {
        }
    }
}
