using System.Web.Script.Serialization;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.User.Profile.View.Entities.Enums;

namespace ThreeBytes.User.Profile.View.Entities
{
    public class UserProfileExternalAuthenticator : BusinessObject<UserProfileExternalAuthenticator>, IBusinessObject<UserProfileExternalAuthenticator>
    {
        public virtual string ExternalIdentifier { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual ExternalAuthenticationType ExternalAuthenticationType { get; set; }
        [ScriptIgnore]
        public virtual UserProfileViewProfile User { get; set; }
    }
}
