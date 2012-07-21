using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.NewestUsers.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.NewestUsers.Data.Concrete.Infrastructure
{
    public class DashboardNewestUsersUnitOfWork : UnitOfWork, IDashboardNewestUsersUnitOfWork
    {
        public DashboardNewestUsersUnitOfWork(IDashboardNewestUsersDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
