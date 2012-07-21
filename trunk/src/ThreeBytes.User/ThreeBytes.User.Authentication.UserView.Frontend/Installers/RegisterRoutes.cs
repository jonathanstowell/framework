using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.User.Authentication.UserView.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "AuthenticationUserDetails",
                "User/Details",
                new { controller = "AuthenticationUserView", action = "Details" }
            );

            routes.MapRoute(
                "AuthenticationUserGetDetailsNoPageParams",
                "User/GetDetails",
                new { controller = "AuthenticationUserView", action = "GetDetails" }
            );

            routes.MapRoute(
                "AuthenticationUserGetDetails",
                "User/GetDetails/{id}",
                new { controller = "AuthenticationUserView", action = "GetDetails" }
            );
        }
    }
}