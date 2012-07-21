using System.Web.Script.Serialization;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.User.Profile.Management.Entities.Enums;

namespace ThreeBytes.User.Profile.Management.Entities
{
    public class UserProfileManagementExternalAuthenticator : BusinessObject<UserProfileManagementExternalAuthenticator>, IBusinessObject<UserProfileManagementExternalAuthenticator>
    {
        public virtual string ExternalIdentifier { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual ExternalAuthenticationType ExternalAuthenticationType { get; set; }
        [ScriptIgnore]
        public virtual UserProfileManagementProfile User { get; set; }
    }
}
