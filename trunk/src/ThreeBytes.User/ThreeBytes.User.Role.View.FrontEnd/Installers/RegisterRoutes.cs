using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.User.Role.View.FrontEnd.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "RoleDetails",
                "Role/Details",
                new { controller = "RoleView", action = "Details" }
            );

            routes.MapRoute(
                "RoleViewGetDetailsNoPageParams",
                "Roles/GetDetails",
                new { controller = "RoleView", action = "GetDetails" }
            );

            routes.MapRoute(
                "RoleViewGetDetails",
                "Roles/GetDetails/{id}",
                new { controller = "RoleView", action = "GetDetails", id = UrlParameter.Optional }
            );
        }
    }
}
