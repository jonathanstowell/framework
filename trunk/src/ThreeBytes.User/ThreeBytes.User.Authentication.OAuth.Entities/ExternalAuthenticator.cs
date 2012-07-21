using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.User.Authentication.OAuth.Entities.Enums;

namespace ThreeBytes.User.Authentication.OAuth.Entities
{
    public class ExternalAuthenticator : BusinessObject<ExternalAuthenticator>, IBusinessObject<ExternalAuthenticator>
    {
        public virtual string ExternalIdentifier { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string Token { get; set; }
        public virtual string TokenSecret { get; set; }
        public virtual ExternalAuthenticationType ExternalAuthenticationType { get; set; }
        public virtual OAuthUser User { get; set; }
    }
}
