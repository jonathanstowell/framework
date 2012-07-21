using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.ProjectHollywood.About.Frontend.Installers
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
                    Controller = "About",
                    Name = "About Us"
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
