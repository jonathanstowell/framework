using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.User.Host.Home.Frontend.Installers
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

                return host;
            }
        }

        public string[] Roles
        {
            get { return new[] { "Admin", "UserAccess" }; }
        }

        public bool RequireAllRoles
        {
            get { return false; }
        }
    }
}
