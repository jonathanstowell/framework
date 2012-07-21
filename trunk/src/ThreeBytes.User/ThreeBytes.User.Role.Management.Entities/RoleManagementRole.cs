using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Role.Management.Entities
{
    [Serializable]
    public class RoleManagementRole : BusinessObject<RoleManagementRole>, IBusinessObject<RoleManagementRole>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }
    }
}
