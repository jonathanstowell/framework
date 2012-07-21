using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.User.Authentication.UserList.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "UserList",
                "Users/List",
                new { controller = "AuthenticationUserList", action = "List" }
            );

            routes.MapRoute(
                "UserListGetPageParams",
                "Users/GetPage",
                new { controller = "AuthenticationUserList", action = "GetPage" }
            );

            routes.MapRoute(
                "UserListGetPage",
                "Users/GetPage/{page}/{datetime}",
                new { controller = "AuthenticationUserList", action = "GetPage", page = "", datetime = "" }
            );

            routes.MapRoute(
                "UserListGet",
                "Users/List/Get/{id}",
                new { controller = "AuthenticationUserList", action = "Get", id = "" }
            );

            routes.MapRoute(
                "UserListGetNewerThanPageParams",
                "Users/List/GetNewerThan",
                new { controller = "AuthenticationUserList", action = "GetNewerThan" }
            );

            routes.MapRoute(
                "UserListGetNewerThan",
                "Users/List/GetNewerThan/{datetime}",
                new { controller = "AuthenticationUserList", action = "GetNewerThan", datetime = "" }
            );
        }
    }
}