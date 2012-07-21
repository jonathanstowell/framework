using System;
using System.Collections.Generic;
using System.Linq;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.Login.Entities
{
    [Serializable]
    public class LoginUser : BusinessObject<LoginUser>, IBusinessObject<LoginUser>
    {
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsVerified { get; set; }
        public virtual bool IsLockedOut { get; set; }
        public virtual int FailedPasswordAttemptCount { get; set; }
        public virtual DateTime FailedPasswordAttemptWindowStart { get; set; }
        public virtual IList<LoginRole> Roles { get; set; }

        public LoginUser()
        {
            Roles = new List<LoginRole>();
        }

        public virtual void AddRole(LoginRole role)
        {
            Roles.Add(role);
            role.Users.Add(this);
        }

        public virtual void RemoveRole(LoginRole role)
        {
            Roles.Remove(role);
            role.Users.Remove(this);
        }

        public virtual string RolesAsString
        {
            get
            {
                return Roles == null ? string.Empty : string.Join("|", Roles.Select(x=>x.Name).ToArray());
            }
        }
    }
}
