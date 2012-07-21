using System;

namespace ThreeBytes.User.Authentication.Email.Entities
{
    public class EmailUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string ApplicationName { get; set; }
        public Guid VerifiedCode { get; set; }
    }
}
