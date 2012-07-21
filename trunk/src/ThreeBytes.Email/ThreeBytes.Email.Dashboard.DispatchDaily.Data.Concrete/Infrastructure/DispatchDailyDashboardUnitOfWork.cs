using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dashboard.DispatchDaily.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Data.Concrete.Infrastructure
{
    public class DispatchDailyDashboardUnitOfWork : UnitOfWork, IDispatchDailyDashboardUnitOfWork
    {
        public DispatchDailyDashboardUnitOfWork(IDispatchDailyDashboardDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
