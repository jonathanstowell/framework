using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Profile.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Profile.Management.Data.Concrete.Infrastructure
{
    public class ProfileManagementUnitOfWork : UnitOfWork, IProfileManagementUnitOfWork
    {
        public ProfileManagementUnitOfWork(IProfileManagementDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
