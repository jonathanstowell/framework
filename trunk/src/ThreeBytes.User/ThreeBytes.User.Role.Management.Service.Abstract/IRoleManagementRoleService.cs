using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Role.Management.Entities;

namespace ThreeBytes.User.Role.Management.Service.Abstract
{
    public interface IRoleManagementRoleService : IKeyedGenericService<RoleManagementRole>
    {
        bool Exists(string name, string applicationName);
    }
}
