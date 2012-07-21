using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Role.List.Entities
{
    [Serializable]
    public class RoleListRole : BusinessObject<RoleListRole>, IBusinessObject<RoleListRole>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }
    }
}
