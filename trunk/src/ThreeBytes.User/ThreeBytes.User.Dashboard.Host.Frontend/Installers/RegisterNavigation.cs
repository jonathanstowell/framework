using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.User.Dashboard.Host.Frontend.Installers
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
                    Controller = "UserDashboardHost",
                    Name = "User Dashboard"
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
