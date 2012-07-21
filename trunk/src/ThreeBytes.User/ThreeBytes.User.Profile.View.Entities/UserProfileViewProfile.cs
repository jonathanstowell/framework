using System;
using System.Collections.Generic;
using System.Linq;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.User.Profile.View.Entities.Enums;

namespace ThreeBytes.User.Profile.View.Entities
{
    [Serializable]
    public class UserProfileViewProfile : HistoricBusinessObject<UserProfileViewProfile>, IHistoricBusinessObject<UserProfileViewProfile>
    {
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Forename { get; set; }
        public virtual string Surname { get; set; }

        public virtual IList<UserProfileExternalAuthenticator> ExternalAuthentications { get; set; }

        public UserProfileViewProfile()
        {
            Forename = string.Empty;
            Surname = string.Empty;
            ExternalAuthentications = new List<UserProfileExternalAuthenticator>();
        }

        public UserProfileViewProfile(UserProfileViewProfile userProfileViewProfile)
            : this()
        {
            ItemId = userProfileViewProfile.ItemId;
            Username = userProfileViewProfile.Username;
            Email = userProfileViewProfile.Email;
            ApplicationName = userProfileViewProfile.ApplicationName;
            Forename = userProfileViewProfile.Forename;
            Surname = userProfileViewProfile.Surname;

            foreach (var provider in userProfileViewProfile.ExternalAuthentications)
            {
                AddExternalAuthenticator(provider);
            }
        }

        public virtual bool HasLinkedExternalProvider(ExternalAuthenticationType provider)
        {
            if (ExternalAuthentications == null)
                return false;

            return ExternalAuthentications.SingleOrDefault(x => x.ExternalAuthenticationType == provider) != null;
        }

        public virtual void AddExternalAuthenticator(UserProfileExternalAuthenticator externalAuthenticator)
        {
            ExternalAuthentications.Add(externalAuthenticator);
            externalAuthenticator.User = this;
        }

        public virtual void RemoveExternalAuthenticator(UserProfileExternalAuthenticator externalAuthenticator)
        {
            ExternalAuthentications.Remove(externalAuthenticator);
            externalAuthenticator.User = this;
        }
    }
}
