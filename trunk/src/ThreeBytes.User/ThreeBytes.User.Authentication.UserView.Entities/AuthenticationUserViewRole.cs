using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.UserView.Entities
{
    [Serializable]
    public class AuthenticationUserViewRole : BusinessObject<AuthenticationUserViewRole>, IBusinessObject<AuthenticationUserViewRole>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }

        [ScriptIgnore]
        public virtual IList<AuthenticationUserViewUser> Users { get; set; }  

        public AuthenticationUserViewRole()
        {
            Users = new List<AuthenticationUserViewUser>();
        }

        public AuthenticationUserViewRole(string name, string applicationName)
            : this()
        {
            Name = name;
            ApplicationName = applicationName;
        }

        public virtual void AddUser(AuthenticationUserViewUser authenticationUser)
        {
            Users.Add(authenticationUser);
            authenticationUser.Roles.Add(this);
        }

        public virtual void RemoveUser(AuthenticationUserViewUser authenticationUser)
        {
            Users.Remove(authenticationUser);
            authenticationUser.Roles.Remove(this);
        }
    }
}
