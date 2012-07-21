using System;
using System.Collections.Generic;
using System.Linq;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.User.Profile.Management.Entities.Enums;

namespace ThreeBytes.User.Profile.Management.Entities
{
    [Serializable]
    public class UserProfileManagementProfile : BusinessObject<UserProfileManagementProfile>, IBusinessObject<UserProfileManagementProfile>
    {
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Forename { get; set; }
        public virtual string Surname { get; set; }

        public virtual IList<UserProfileManagementExternalAuthenticator> ExternalAuthentications { get; set; }

        public UserProfileManagementProfile()
        {
            Forename = string.Empty;
            Surname = string.Empty;
            ExternalAuthentications = new List<UserProfileManagementExternalAuthenticator>();
        }

        public virtual bool HasLinkedExternalProvider(ExternalAuthenticationType provider)
        {
            if (ExternalAuthentications == null)
                return false;

            return ExternalAuthentications.SingleOrDefault(x => x.ExternalAuthenticationType == provider) != null;
        }

        public virtual void AddExternalAuthenticator(UserProfileManagementExternalAuthenticator externalAuthenticator)
        {
            ExternalAuthentications.Add(externalAuthenticator);
            externalAuthenticator.User = this;
        }

        public virtual void RemoveExternalAuthenticator(UserProfileManagementExternalAuthenticator externalAuthenticator)
        {
            ExternalAuthentications.Remove(externalAuthenticator);
            externalAuthenticator.User = this;
        }
    }
}
