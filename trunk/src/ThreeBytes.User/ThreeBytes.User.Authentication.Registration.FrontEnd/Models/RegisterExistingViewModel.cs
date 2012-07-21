using ThreeBytes.User.Authentication.Registration.Entities;

namespace ThreeBytes.User.Authentication.Registration.FrontEnd.Models
{
    public class RegisterExistingViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Success { get; set; }
        public ExternalUser ExternalUser { get; set; }

        public RegisterExistingViewModel()
        {}

        public RegisterExistingViewModel(string username, string email, ExternalUser user)
        {
            UserName = username;
            Email = email;
            ExternalUser = user;
        }
    }
}