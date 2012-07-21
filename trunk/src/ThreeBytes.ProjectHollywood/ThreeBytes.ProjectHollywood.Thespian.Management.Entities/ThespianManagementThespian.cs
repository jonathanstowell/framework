using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities.Enums;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Entities
{
    [Serializable]
    public class ThespianManagementThespian : BusinessObject<ThespianManagementThespian>, IBusinessObject<ThespianManagementThespian>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string ProfileImageLocation { get; set; }
        public virtual string ProfileThumbnailImageLocation { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual string Email { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string Location { get; set; }
        public virtual int? Height { get; set; }
        public virtual int? Weight { get; set; }
        public virtual int? PlayingAge { get; set; }
        public virtual EyeColour EyeColour { get; set; }
        public virtual HairLength HairLength { get; set; }
        public virtual string Summary { get; set; }
        public virtual string Twitter { get; set; }
        public virtual string Facebook { get; set; }
        public virtual string Spotlight { get; set; }
        public virtual string Imdb { get; set; }
        public virtual ThespianType ThespianType { get; set; }
    }
}
