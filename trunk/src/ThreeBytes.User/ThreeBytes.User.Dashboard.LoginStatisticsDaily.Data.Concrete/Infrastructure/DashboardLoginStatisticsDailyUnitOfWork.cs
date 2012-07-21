using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Data.Concrete.Infrastructure
{
    public class DashboardLoginStatisticsDailyUnitOfWork : UnitOfWork, IDashboardLoginStatisticsDailyUnitOfWork
    {
        public DashboardLoginStatisticsDailyUnitOfWork(IDashboardLoginStatisticsDailyDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
