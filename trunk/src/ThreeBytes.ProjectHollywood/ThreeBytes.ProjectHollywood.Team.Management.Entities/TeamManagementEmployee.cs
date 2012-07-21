using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.ProjectHollywood.Team.Management.Entities
{
    [Serializable]
    public class TeamManagementEmployee : BusinessObject<TeamManagementEmployee>, IBusinessObject<TeamManagementEmployee>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string JobTitle { get; set; }
        public virtual string ProfileImageLocation { get; set; }
        public virtual string ProfileThumbnailImageLocation { get; set; }
        public virtual string Summary { get; set; }
    }
}
