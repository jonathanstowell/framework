using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Concrete.Infrastructure
{
    public class DashboardLoginStatisticsQuarterlyUnitOfWork : UnitOfWork, IDashboardLoginStatisticsQuarterlyUnitOfWork
    {
        public DashboardLoginStatisticsQuarterlyUnitOfWork(IDashboardLoginStatisticsQuarterlyDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
