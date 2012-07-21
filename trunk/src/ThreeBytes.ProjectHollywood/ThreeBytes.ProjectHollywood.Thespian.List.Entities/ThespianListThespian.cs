using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities.Enums;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Entities
{
    [Serializable]
    public class ThespianListThespian : BusinessObject<ThespianListThespian>, IBusinessObject<ThespianListThespian>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string ProfileImageLocation { get; set; }
        public virtual string ProfileThumbnailImageLocation { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ThespianType ThespianType { get; set; }
    }
}
