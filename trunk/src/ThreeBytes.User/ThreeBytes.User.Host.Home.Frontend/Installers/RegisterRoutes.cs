using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.User.Host.Home.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "UserHost",
                "UserSystem",
                new { controller = "UserHost", action = "Index" }
            );
        }
    }
}