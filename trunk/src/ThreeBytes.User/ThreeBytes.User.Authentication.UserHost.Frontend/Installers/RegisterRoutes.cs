using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.User.Authentication.UserHost.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "AuthenticationUserHost",
                "Users",
                new { controller = "AuthenticationUserHost", action = "Index" }
            );
        }
    }
}