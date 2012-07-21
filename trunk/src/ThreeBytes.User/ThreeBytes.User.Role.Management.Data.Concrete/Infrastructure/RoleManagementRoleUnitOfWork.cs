using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Role.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Role.Management.Data.Concrete.Infrastructure
{
    public class RoleManagementRoleUnitOfWork : UnitOfWork, IRoleManagementRoleUnitOfWork
    {
        public RoleManagementRoleUnitOfWork(IRoleManagementRoleDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
