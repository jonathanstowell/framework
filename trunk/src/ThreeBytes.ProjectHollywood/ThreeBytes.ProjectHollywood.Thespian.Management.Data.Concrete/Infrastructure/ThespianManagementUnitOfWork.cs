using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Data.Concrete.Infrastructure
{
    public class ThespianManagementUnitOfWork : UnitOfWork, IThespianManagementUnitOfWork
    {
        public ThespianManagementUnitOfWork(IThespianManagementDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
