using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.Password.Entities
{
    [Serializable]
    public class PasswordManagementUser : BusinessObject<PasswordManagementUser>, IBusinessObject<PasswordManagementUser>
    {
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsLockedOut { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual bool IsVerified { get; set; }
        public virtual Guid? UnlockCode { get; set; }
        public virtual Guid? ResetPasswordCode { get; set; }
        public virtual string Password { get; set; }
        public virtual string ConfirmPassword { get; set; }
    }
}
