using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.Logging.Exceptions.Host.Frontend.Installers
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
                    Controller = "LoggingExceptionsHost",
                    Name = "Exceptions"
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
