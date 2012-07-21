using ThreeBytes.User.Authentication.OAuth.Entities;

namespace ThreeBytes.User.Authentication.OAuth.Frontend.Models
{
    public class LinkViewModel
    {
        public string Username { get; set; }

        public LinkViewModel(OAuthUser user)
        {
            Username = user.Username;
        }
    }
}
