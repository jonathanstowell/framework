using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.Email.Template.Host.Frontend.Installers
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

                NavigationNode template = new NavigationNode
                                          {
                                              Action = "Index",
                                              Controller = "EmailTemplateHost",
                                              Name = "Templates"
                                          };

                host.Children.Add(template);

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
