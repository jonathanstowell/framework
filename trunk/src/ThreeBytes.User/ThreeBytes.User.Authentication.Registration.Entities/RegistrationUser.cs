using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.Registration.Entities
{
    [Serializable]
    public class RegistrationUser : BusinessObject<RegistrationUser>, IBusinessObject<RegistrationUser>
    {
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Password { get; set; }
        public virtual string ConfirmPassword { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsVerified { get; set; }
        public virtual Guid VerifiedCode { get; set; }
    }
}
