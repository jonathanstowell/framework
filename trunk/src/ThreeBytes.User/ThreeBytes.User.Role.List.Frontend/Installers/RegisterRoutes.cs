using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.User.Role.List.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "RoleList",
                "Roles/List",
                new { controller = "RoleList", action = "List" }
            );

            routes.MapRoute(
                "RoleListGetPageParams",
                "Roles/GetPage",
                new { controller = "RoleList", action = "GetPage" }
            );

            routes.MapRoute(
                "RoleListGetPage",
                "Roles/GetPage/{page}/{datetime}",
                new { controller = "RoleList", action = "GetPage", page = "", datetime = "" }
            );

            routes.MapRoute(
                "RoleListGet",
                "Roles/List/Get/{id}",
                new { controller = "RoleList", action = "Get", id = "" }
            );

            routes.MapRoute(
                "RoleListGetNewerThanPageParams",
                "Roles/List/GetNewerThan",
                new { controller = "RoleList", action = "GetNewerThan" }
            );

            routes.MapRoute(
                "RoleListGetNewerThan",
                "Roles/List/GetNewerThan/{datetime}",
                new { controller = "RoleList", action = "GetNewerThan", datetime = "" }
            );
        }
    }
}