using System;
using System.Collections.Generic;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Authentication.OAuth.Entities
{
    [Serializable]
    public class OAuthRole : BusinessObject<OAuthRole>, IBusinessObject<OAuthRole>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual IList<OAuthUser> Users { get; set; }

        public OAuthRole()
        {
            Users = new List<OAuthUser>();
        }

        public OAuthRole(string name, string applicationName)
            : this()
        {
            Name = name;
            ApplicationName = applicationName;
        }

        public virtual void AddUser(OAuthUser user)
        {
            Users.Add(user);
        }

        public virtual void RemoveUser(OAuthUser user)
        {
            Users.Remove(user);
        }
    }
}
