using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.ProjectHollywood.Team.View.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "TeamDetails",
                "Team/Details",
                new { controller = "TeamView", action = "Details" }
            );

            routes.MapRoute(
                "TeamGetDetails",
                "Team/GetDetails/{id}",
                new { controller = "TeamView", action = "GetDetails", id = "" }
            );

            routes.MapRoute(
                "TeamViewProfileImage",
                "Team/GetProfileImage/{filename}",
                new { controller = "TeamView", action = "GetProfileImage", filename = "" }
            );
        }
    }
}