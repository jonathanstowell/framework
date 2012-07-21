using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.User.Authentication.UserHost.Frontend.Installers
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
                    Controller = "Users",
                    Name = "User Management"
                };

                host.Children.Add(users);

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
