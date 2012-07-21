using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "ThespianList",
                "OurClients/List",
                new { controller = "ThespianList", action = "List" }
            );

            routes.MapRoute(
                "ThespianListGetArtists",
                "OurClients/GetArtists",
                new { controller = "ThespianList", action = "GetArtists" }
            );

            routes.MapRoute(
                "ThespianListGet",
                "OurClients/List/Get/{id}",
                new { controller = "ThespianList", action = "Get", id = "" }
            );
        }
    }
}