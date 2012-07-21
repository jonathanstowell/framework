using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.User.Authentication.Login.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "Login",
                "Login",
                new { controller = "Login", action = "Login" }
            );

            routes.MapRoute(
                "LoginRedirect",
                "Login/RedirectUrl/{controllername}/{actionname}",
                new { controller = "Login", action = "Login", controllername = "", actionname = "" }
            );
        }
    }
}
