using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Data.Concrete.Infrastructure
{
    public class DashboardRegistrationStatisticsMonthlyUnitOfWork : UnitOfWork, IDashboardRegistrationStatisticsMonthlyUnitOfWork
    {
        public DashboardRegistrationStatisticsMonthlyUnitOfWork(IDashboardRegistrationStatisticsMonthlyDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
