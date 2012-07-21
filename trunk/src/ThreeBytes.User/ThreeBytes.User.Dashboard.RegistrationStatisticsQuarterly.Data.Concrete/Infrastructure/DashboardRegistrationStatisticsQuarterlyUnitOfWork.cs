using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Concrete.Infrastructure
{
    public class DashboardRegistrationStatisticsQuarterlyUnitOfWork : UnitOfWork, IDashboardRegistrationStatisticsQuarterlyUnitOfWork
    {
        public DashboardRegistrationStatisticsQuarterlyUnitOfWork(IDashboardRegistrationStatisticsQuarterlyDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
