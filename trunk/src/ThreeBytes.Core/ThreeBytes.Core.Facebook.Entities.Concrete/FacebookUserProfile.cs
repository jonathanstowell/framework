using ThreeBytes.Core.Facebook.Entities.Abstract;

namespace ThreeBytes.Core.Facebook.Entities.Concrete
{
    public class FacebookUserProfile : IFacebookUserProfile
    {
        public string Identifier { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
