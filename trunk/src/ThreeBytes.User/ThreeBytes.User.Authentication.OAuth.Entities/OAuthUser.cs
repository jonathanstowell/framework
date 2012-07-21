using System;
using System.Collections.Generic;
using System.Linq;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.User.Authentication.OAuth.Entities.Enums;

namespace ThreeBytes.User.Authentication.OAuth.Entities
{
    [Serializable]
    public class OAuthUser : BusinessObject<OAuthUser>, IBusinessObject<OAuthUser>
    {
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Email { get; set; }
        public virtual IList<OAuthRole> Roles { get; set; }
        public virtual IList<ExternalAuthenticator> ExternalAuthentications { get; set; }

        public OAuthUser()
        {
            Roles = new List<OAuthRole>();
            ExternalAuthentications = new List<ExternalAuthenticator>();
        }

        public virtual void AddRole(OAuthRole role)
        {
            Roles.Add(role);
            role.Users.Add(this);
        }

        public virtual void RemoveRole(OAuthRole role)
        {
            Roles.Remove(role);
            role.Users.Remove(this);
        }

        public virtual bool HasLinkedExternalProvider(ExternalAuthenticationType provider)
        {
            if (ExternalAuthentications == null)
                return false;

            return ExternalAuthentications.SingleOrDefault(x => x.ExternalAuthenticationType == provider) != null;
        }

        public virtual void AddExternalAuthenticator(ExternalAuthenticator externalAuthenticator)
        {
            ExternalAuthentications.Add(externalAuthenticator);
            externalAuthenticator.User = this;
        }

        public virtual void RemoveExternalAuthenticator(ExternalAuthenticator externalAuthenticator)
        {
            ExternalAuthentications.Remove(externalAuthenticator);
            externalAuthenticator.User = this;
        }

        public virtual string RolesAsString
        {
            get
            {
                return Roles == null ? string.Empty : string.Join("|", Roles.Select(x => x.Name).ToArray());
            }
        }
    }
}
