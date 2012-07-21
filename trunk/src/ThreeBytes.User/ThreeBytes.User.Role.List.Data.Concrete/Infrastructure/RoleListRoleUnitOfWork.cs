using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Role.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Role.List.Data.Concrete.Infrastructure
{
    public class RoleListRoleUnitOfWork : UnitOfWork, IRoleListRoleUnitOfWork
    {
        public RoleListRoleUnitOfWork(IRoleListRoleDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
