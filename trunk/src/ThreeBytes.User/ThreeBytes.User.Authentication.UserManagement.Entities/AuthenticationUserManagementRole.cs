using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.UserManagement.Entities
{
    [Serializable]
    public class AuthenticationUserManagementRole : BusinessObject<AuthenticationUserManagementRole>, IBusinessObject<AuthenticationUserManagementRole>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }

        [ScriptIgnore]
        public virtual IList<AuthenticationUserManagementUser> Users { get; set; }

        public AuthenticationUserManagementRole()
        {
            Users = new List<AuthenticationUserManagementUser>();
        }

        public AuthenticationUserManagementRole(string name, string applicationName)
            : this()
        {
            Name = name;
            ApplicationName = applicationName;
        }

        public virtual void AddUser(AuthenticationUserManagementUser authenticationUser)
        {
            Users.Add(authenticationUser);
        }

        public virtual void RemoveUser(AuthenticationUserManagementUser authenticationUser)
        {
            Users.Remove(authenticationUser);
        }
    }
}
