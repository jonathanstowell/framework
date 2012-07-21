namespace ThreeBytes.User.Authentication.Registration.FrontEnd.Models
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Success { get; set; }
    }
}
