using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.Email.Dispatch.Host.Frontend.Installers
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

                NavigationNode dispatch = new NavigationNode
                {
                    Action = "Index",
                    Controller = "EmailDispatchHost",
                    Name = "Dispatch"
                };

                host.Children.Add(dispatch);

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
