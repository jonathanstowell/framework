using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Role.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Role.View.Data.Concrete.Infrastructure
{
    public class RoleViewRoleDatabaseFactory : AbstractDatabaseFactoryBase, IRoleViewRoleDatabaseFactory
    {
        public RoleViewRoleDatabaseFactory(IProvideRoleViewSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
