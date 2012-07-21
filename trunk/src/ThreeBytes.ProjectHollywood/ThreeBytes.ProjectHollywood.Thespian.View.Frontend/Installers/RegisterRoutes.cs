using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "ThespianViewDetails",
                "OurClients/Details",
                new { controller = "ThespianView", action = "Details" }
            );

            routes.MapRoute(
                "ThespianViewGetDetails",
                "OurClients/GetDetails/{id}",
                new { controller = "ThespianView", action = "GetDetails", id = "" }
            );

            routes.MapRoute(
                "ThespianViewProfileImage",
                "OurClients/GetProfileImage/{filename}",
                new { controller = "ThespianView", action = "GetProfileImage", filename = "" }
            );
        }
    }
}