using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.Logging.Host.Home.Frontend.Installers
{
    public class RegisterDashboardNavigation : IRegisterNavigation
    {
        public NavigationNode Path
        {
            get
            {
                NavigationNode host = new NavigationNode
                {
                    Action = "Index",
                    Controller = "LoggingHost",
                    Name = "Dashboard"
                };

                return host;
            }
        }

        public string[] Roles
        {
            get { return new[] { "Admin", "LoggingAccess" }; }
        }

        public bool RequireAllRoles
        {
            get { return false; }
        }
    }
}
