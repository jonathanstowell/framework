using System;
using System.Collections.Generic;
using System.Linq;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.User.Authentication.Registration.Entities.Enums;

namespace ThreeBytes.User.Authentication.Registration.Entities
{
    [Serializable]
    public class ExternalUser : BusinessObject<ExternalUser>, IBusinessObject<ExternalUser>
    {
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual IList<ExternalAuthenticator> ExternalAuthentications { get; set; }

        public ExternalUser()
        {
            ExternalAuthentications = new List<ExternalAuthenticator>();
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
    }
}
