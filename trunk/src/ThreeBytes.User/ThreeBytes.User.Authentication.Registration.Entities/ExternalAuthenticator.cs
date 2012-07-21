using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.User.Authentication.Registration.Entities.Enums;

namespace ThreeBytes.User.Authentication.Registration.Entities
{
    public class ExternalAuthenticator : BusinessObject<ExternalAuthenticator>, IBusinessObject<ExternalAuthenticator>
    {
        public virtual string ExternalIdentifier { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual ExternalAuthenticationType ExternalAuthenticationType { get; set; }
        public virtual ExternalUser User { get; set; }
    }
}
