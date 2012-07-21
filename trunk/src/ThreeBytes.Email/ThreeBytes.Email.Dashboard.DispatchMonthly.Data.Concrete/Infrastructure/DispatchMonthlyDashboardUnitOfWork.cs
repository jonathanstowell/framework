using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Data.Concrete.Infrastructure
{
    public class DispatchMonthlyDashboardUnitOfWork : UnitOfWork, IDispatchMonthlyDashboardUnitOfWork
    {
        public DispatchMonthlyDashboardUnitOfWork(IDispatchMonthlyDashboardDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
