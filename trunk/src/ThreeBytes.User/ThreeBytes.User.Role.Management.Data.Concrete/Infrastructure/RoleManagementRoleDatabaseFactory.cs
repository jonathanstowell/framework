using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Role.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Role.Management.Data.Concrete.Infrastructure
{
    public class RoleManagementRoleDatabaseFactory : AbstractDatabaseFactoryBase, IRoleManagementRoleDatabaseFactory
    {
        public RoleManagementRoleDatabaseFactory(IProvideRoleManagementSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
