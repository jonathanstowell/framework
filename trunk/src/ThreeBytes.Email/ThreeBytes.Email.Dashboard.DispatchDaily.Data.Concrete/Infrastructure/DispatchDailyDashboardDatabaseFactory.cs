using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dashboard.DispatchDaily.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Data.Concrete.Infrastructure
{
    public class DispatchDailyDashboardDatabaseFactory : AbstractDatabaseFactoryBase, IDispatchDailyDashboardDatabaseFactory
    {
        public DispatchDailyDashboardDatabaseFactory(IProvideDispatchDailyDashboardSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
