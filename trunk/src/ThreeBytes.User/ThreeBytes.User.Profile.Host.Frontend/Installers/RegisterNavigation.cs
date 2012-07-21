using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.User.Profile.Host.Frontend.Installers
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
                    Controller = "UserSystem",
                    Name = "User System"
                };

                NavigationNode users = new NavigationNode
                {
                    Action = "Index",
                    Controller = "ProfileHost",
                    Name = "Profile"
                };

                host.Children.Add(users);

                return host;
            }
        }

        public string[] Roles
        {
            get { return new[] { "Creator", "Admin", "UserAccess", "ProfileAccess" }; }
        }

        public bool RequireAllRoles
        {
            get { return false; }
        }
    }
}
