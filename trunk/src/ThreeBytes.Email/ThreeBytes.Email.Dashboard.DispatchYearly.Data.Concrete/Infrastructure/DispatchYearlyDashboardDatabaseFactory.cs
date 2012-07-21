using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dashboard.DispatchYearly.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Data.Concrete.Infrastructure
{
    public class DispatchYearlyDashboardDatabaseFactory : AbstractDatabaseFactoryBase, IDispatchYearlyDashboardDatabaseFactory
    {
        public DispatchYearlyDashboardDatabaseFactory(IProvideDispatchYearlyDashboardSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
