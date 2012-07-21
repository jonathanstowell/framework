using System;

namespace ThreeBytes.User.Authentication.Registration.FrontEnd.Models
{
    public class VerifyAccountViewModel
    {
        public string UserIdentifier { get; set; }
        public Guid? VerifiedCode { get; set; }
        public bool Success { get; set; }
    }
}
