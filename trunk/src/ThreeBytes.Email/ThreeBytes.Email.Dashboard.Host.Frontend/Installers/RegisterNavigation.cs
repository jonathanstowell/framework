using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.Email.Dashboard.Host.Frontend.Installers
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
                    Controller = "EmailSystem",
                    Name = "Email System"
                };

                NavigationNode dashboard = new NavigationNode
                {
                    Action = "Index",
                    Controller = "EmailDashboardHost",
                    Name = "Dashboard"
                };

                host.Children.Add(dashboard);

                return host;
            }
        }

        public string[] Roles
        {
            get { return new[] { "Creator", "Admin", "EmailAccess" }; }
        }

        public bool RequireAllRoles
        {
            get { return false; }
        }
    }
}