using System;
using System.Security.Principal;

namespace ThreeBytes.Core.Security.Concrete
{
    public class ThreeBytesPrincipal : IPrincipal
    {
        private readonly IIdentity identity;
        private readonly Guid userId;
        private readonly string externalProvider;
        private readonly string[] roles;

        public ThreeBytesPrincipal(IIdentity identity, Guid userId, string[] roles, string externalProvider)
        {
            this.identity = identity;
            this.userId = userId;
            this.externalProvider = externalProvider;
            this.roles = new string[roles.Length];
            roles.CopyTo(this.roles, 0);
            Array.Sort(this.roles);
        }

        public IIdentity Identity
        {
            get { return identity; }
        }

        public Guid UserId
        {
            get { return userId; }
        }

        public string ExternalProvider
        {
            get { return externalProvider; }
        }

        public bool IsInRole(string role)
        {
            return Array.BinarySearch(roles, role) >= 0;
        }

        public bool IsInAllRoles(params string[] roles)
        {
            foreach (string searchrole in roles)
            {
                if (Array.BinarySearch(this.roles, searchrole) < 0)
                    return false;
            }
            return true;
        }

        public bool IsInAnyRoles(params string[] roles)
        {
            foreach (string searchrole in roles)
            {
                if (Array.BinarySearch(this.roles, searchrole) >= 0)
                    return true;
            }
            return false;
        }
    }
}
