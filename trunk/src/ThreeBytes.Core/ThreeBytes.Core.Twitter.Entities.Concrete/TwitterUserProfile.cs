using ThreeBytes.Core.Twitter.Entities.Abstract;

namespace ThreeBytes.Core.Twitter.Entities.Concrete
{
    public class TwitterUserProfile : ITwitterUserProfile
    {
        public string Identifier { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }
    }
}
