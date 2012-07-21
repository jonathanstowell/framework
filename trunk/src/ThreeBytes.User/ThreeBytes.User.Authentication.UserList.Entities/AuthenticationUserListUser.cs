using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.UserList.Entities
{
    [Serializable]
    public class AuthenticationUserListUser : BusinessObject<AuthenticationUserListUser>, IBusinessObject<AuthenticationUserListUser>
    {
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsVerified { get; set; }
        public virtual bool IsLockedOut { get; set; }
    }
}
