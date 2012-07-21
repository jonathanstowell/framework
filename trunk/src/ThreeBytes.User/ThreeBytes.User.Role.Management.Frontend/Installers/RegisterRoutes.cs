using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.User.Role.Management.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "RoleCreate",
                "Role/Create",
                new { controller = "RoleManagement", action = "Create" }
            );

            routes.MapRoute(
                "RoleEditPageParams",
                "Role/Edit",
                new { controller = "RoleManagement", action = "Edit" }
            );

            routes.MapRoute(
                "RoleEdit",
                "Role/Edit/{id}",
                new { controller = "RoleManagement", action = "Edit" }
            );

            routes.MapRoute(
                "RoleRenamePageParams",
                "Role/Rename",
                new { controller = "RoleManagement", action = "Edit" }
            );

            routes.MapRoute(
                "RoleRename",
                "Role/Rename/{id}/{name}",
                new { controller = "RoleManagement", action = "Edit", id = "", name = "" }
            );

            routes.MapRoute(
                "RoleDeletePageParams",
                "Role/Delete",
                new { controller = "RoleManagement", action = "Delete" }
            );

            routes.MapRoute(
                "RoleDelete",
                "Role/Delete/{id}",
                new { controller = "RoleManagement", action = "Delete", id = "" }
            );
        }
    }
}
