using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Concrete.Infrastructure
{
    public class DashboardLoginStatisticsMonthlyUnitOfWork : UnitOfWork, IDashboardLoginStatisticsMonthlyUnitOfWork
    {
        public DashboardLoginStatisticsMonthlyUnitOfWork(IDashboardLoginStatisticsMonthlyDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
