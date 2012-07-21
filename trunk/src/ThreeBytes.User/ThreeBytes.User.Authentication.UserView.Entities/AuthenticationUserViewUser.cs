using System;
using System.Collections.Generic;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.UserView.Entities
{
    [Serializable]
    public class AuthenticationUserViewUser : HistoricBusinessObject<AuthenticationUserViewUser>, IHistoricBusinessObject<AuthenticationUserViewUser>
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
        public virtual IList<AuthenticationUserViewRole> Roles { get; set; }

        public AuthenticationUserViewUser()
        {
            Roles = new List<AuthenticationUserViewRole>();
        }

        public AuthenticationUserViewUser(AuthenticationUserViewUser authenticationUser)
            : this()
        {
            Username = authenticationUser.Username;
            ItemId = authenticationUser.ItemId;
            ApplicationName = authenticationUser.ApplicationName;
            Email = authenticationUser.Email;
            IsVerified = authenticationUser.IsVerified;
            VerifiedCode = authenticationUser.VerifiedCode;
            IsOriginalAdministrator = authenticationUser.IsOriginalAdministrator;
            IsLockedOut = authenticationUser.IsLockedOut;
            UnlockCode = authenticationUser.UnlockCode;
            FailedPasswordAttemptCount = authenticationUser.FailedPasswordAttemptCount;
            FailedPasswordAttemptWindowStart = authenticationUser.FailedPasswordAttemptWindowStart;

            foreach (var role in authenticationUser.Roles)
            {
                AddRole(role);
            }
        }

        public virtual void AddRole(AuthenticationUserViewRole role)
        {
            Roles.Add(role);
            role.Users.Add(this);
        }

        public virtual void RemoveRole(AuthenticationUserViewRole role)
        {
            Roles.Remove(role);
            role.Users.Add(this);
        }
    }
}
