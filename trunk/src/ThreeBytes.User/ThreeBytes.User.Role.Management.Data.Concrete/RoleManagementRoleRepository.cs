using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Role.Management.Data.Abstract;
using ThreeBytes.User.Role.Management.Data.Abstract.Infrastructure;
using ThreeBytes.User.Role.Management.Entities;

namespace ThreeBytes.User.Role.Management.Data.Concrete
{
    public class RoleManagementRoleRepository : KeyedGenericRepository<RoleManagementRole>, IRoleManagementRoleRepository
    {
        public RoleManagementRoleRepository(IRoleManagementRoleDatabaseFactory databaseFactory, IRoleManagementRoleUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public bool Exists(string name, string applicationName)
        {
            return Session.QueryOver<RoleManagementRole>()
                       .Where(x => x.Name == name)
                       .And(x => x.ApplicationName == applicationName)
                       .RowCount() != 0;
        }
    }
}
