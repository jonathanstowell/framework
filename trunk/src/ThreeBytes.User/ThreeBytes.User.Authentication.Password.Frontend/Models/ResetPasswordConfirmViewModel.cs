using System;

namespace ThreeBytes.User.Authentication.Password.Frontend.Models
{
    public class ResetPasswordConfirmViewModel
    {
        public string UserIdentifier { get; set; }
        public Guid? ResetPasswordCode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Success { get; set; }
    }
}
