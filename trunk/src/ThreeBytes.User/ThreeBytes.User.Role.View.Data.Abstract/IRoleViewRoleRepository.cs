using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Role.View.Entities;

namespace ThreeBytes.User.Role.View.Data.Abstract
{
    public interface IRoleViewRoleRepository : IHistoricKeyedGenericRepository<RoleViewRole>
    {
        bool Exists(Guid itemId, string name, string applicationName);
    }
}
