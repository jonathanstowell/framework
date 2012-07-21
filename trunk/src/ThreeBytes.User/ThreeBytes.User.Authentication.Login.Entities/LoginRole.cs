using System;
using System.Collections.Generic;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.Login.Entities
{
    [Serializable]
    public class LoginRole : BusinessObject<LoginRole>, IBusinessObject<LoginRole>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual IList<LoginUser> Users { get; set; }

        public LoginRole()
        {
            Users = new List<LoginUser>();
        }

        public LoginRole(string name, string applicationName)
            : this()
        {
            Name = name;
            ApplicationName = applicationName;
        }

        public virtual void AddUser(LoginUser user)
        {
            Users.Add(user);
        }

        public virtual void RemoveUser(LoginUser user)
        {
            Users.Remove(user);
        }
    }
}
