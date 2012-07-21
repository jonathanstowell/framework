using System;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Role.View.Entities;

namespace ThreeBytes.User.Role.View.Service.Abstract
{
    public interface IRoleViewRoleService : IHistoricKeyedGenericService<RoleViewRole>
    {
        bool Exists(Guid itemId, string name, string applicationName);
    }
}
