using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Data.Concrete.Infrastructure
{
    public class DispatchQuarterlyDashboardUnitOfWork : UnitOfWork, IDispatchQuarterlyDashboardUnitOfWork
    {
        public DispatchQuarterlyDashboardUnitOfWork(IDispatchQuarterlyDashboardDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
