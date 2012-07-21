using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Role.View.Entities
{
    [Serializable]
    public class RoleViewRole : HistoricBusinessObject<RoleViewRole>, IHistoricBusinessObject<RoleViewRole>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }

        public RoleViewRole(){}

        public RoleViewRole(RoleViewRole role)
        {
            Name = role.Name;
            ApplicationName = role.ApplicationName;
            ItemId = role.ItemId;
        }
    }
}
