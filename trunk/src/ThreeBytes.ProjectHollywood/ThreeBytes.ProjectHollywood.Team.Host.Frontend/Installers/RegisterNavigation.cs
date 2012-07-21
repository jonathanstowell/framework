using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.ProjectHollywood.Team.Host.Frontend.Installers
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
                    Controller = "Team",
                    Name = "Team"
                };

                return host;
            }
        }

        public string[] Roles
        {
            get { return new string[0]; }
        }

        public bool RequireAllRoles
        {
            get { return false; }
        }
    }
}
