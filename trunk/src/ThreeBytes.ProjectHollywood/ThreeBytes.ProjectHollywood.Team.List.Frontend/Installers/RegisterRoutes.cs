using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.ProjectHollywood.Team.List.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "TeamList",
                "Team/List",
                new { controller = "TeamList", action = "List" }
            );

            routes.MapRoute(
                "TeamGetAll",
                "Team/GetAll",
                new { controller = "TeamList", action = "GetAll" }
            );

            routes.MapRoute(
                "TeamListGet",
                "Team/List/Get/{id}",
                new { controller = "TeamList", action = "Get", id = "" }
            );
        }
    }
}