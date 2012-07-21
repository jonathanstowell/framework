using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.User.Role.Host.Frontend.Installers
{
    public class RegisterNavigation : IRegisterNavigation
    {
        public NavigationNode Path
        {
            get
            {
                NavigationNode host = new NavigationNode
                {
                    Action = "Index",
                    Controller = "UserHost",
                    Name = "User System"
                };

                NavigationNode roles = new NavigationNode
                {
                    Controller = "Roles",
                    Name = "Role Management"
                };

                host.Children.Add(roles);

                return host;
            }
        }

        public string[] Roles
        {
            get { return new[] { "Creator", "Admin", "UserAccess" }; }
        }

        public bool RequireAllRoles
        {
            get { return false; }
        }
    }
}
