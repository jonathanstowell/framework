using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Data.Concrete.Infrastructure
{
    public class DashboardLoginStatisticsYearlyUnitOfWork : UnitOfWork, IDashboardLoginStatisticsYearlyUnitOfWork
    {
        public DashboardLoginStatisticsYearlyUnitOfWork(IDashboardLoginStatisticsYearlyDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
