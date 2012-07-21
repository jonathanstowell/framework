using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.ActiveUsers.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Data.Concrete.Infrastructure
{
    public class DashboardActiveUsersUnitOfWork : UnitOfWork, IDashboardActiveUsersUnitOfWork
    {
        public DashboardActiveUsersUnitOfWork(IDashboardActiveUsersDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
