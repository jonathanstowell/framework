using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dashboard.DispatchYearly.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Data.Concrete.Infrastructure
{
    public class DispatchYearlyDashboardUnitOfWork : UnitOfWork, IDispatchYearlyDashboardUnitOfWork
    {
        public DispatchYearlyDashboardUnitOfWork(IDispatchYearlyDashboardDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
