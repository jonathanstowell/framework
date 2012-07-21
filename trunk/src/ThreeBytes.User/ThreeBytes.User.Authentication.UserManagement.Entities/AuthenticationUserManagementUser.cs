using System;
using System.Collections.Generic;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.UserManagement.Entities
{
    [Serializable]
    public class AuthenticationUserManagementUser : BusinessObject<AuthenticationUserManagementUser>, IBusinessObject<AuthenticationUserManagementUser>
    {
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsVerified { get; set; }
        public virtual Guid? VerifiedCode { get; set; }
        public virtual bool IsOriginalAdministrator { get; set; }
        public virtual bool IsLockedOut { get; set; }
        public virtual Guid? UnlockCode { get; set; }
        public virtual int FailedPasswordAttemptCount { get; set; }
        public virtual DateTime? FailedPasswordAttemptWindowStart { get; set; }

        public virtual IList<AuthenticationUserManagementRole> Roles { get; set; }

        public AuthenticationUserManagementUser()
        {
            Roles = new List<AuthenticationUserManagementRole>();
        }

        public virtual void AddRole(AuthenticationUserManagementRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            if (Roles.Contains(role))
                return;

            Roles.Add(role);
            role.Users.Add(this);
        }

        public virtual void RemoveRole(AuthenticationUserManagementRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            if(!Roles.Contains(role))
                return;

            Roles.Remove(role);
            role.Users.Remove(this);
        }
    }
}
