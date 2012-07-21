using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Role.Management.Entities;

namespace ThreeBytes.User.Role.Management.Data.Abstract
{
    public interface IRoleManagementRoleRepository : IKeyedGenericRepository<RoleManagementRole>
    {
        bool Exists(string name, string applicationName);
    }
}
