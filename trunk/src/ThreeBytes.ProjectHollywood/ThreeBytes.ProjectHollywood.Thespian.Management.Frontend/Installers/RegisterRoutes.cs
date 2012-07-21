using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "ThespianManagementCreate",
                "OurClients/Create",
                new { controller = "ThespianManagement", action = "Create" }
            );

            routes.MapRoute(
                "ThespianManagementEdit",
                "OurClients/Edit",
                new { controller = "ThespianManagement", action = "Edit" }
            );

            routes.MapRoute(
                "ThespianManagementRename",
                "OurClients/Rename",
                new { controller = "ThespianManagement", action = "Rename" }
            );

            routes.MapRoute(
                "ThespianManagementUpdateProfileImage",
                "OurClients/UpdateProfileImage",
                new { controller = "ThespianManagement", action = "UpdateProfileImage" }
            );

            routes.MapRoute(
                "ThespianManagementDelete",
                "OurClients/Delete",
                new { controller = "ThespianManagement", action = "Delete" }
            );

            routes.MapRoute(
                "ThespianManagementGet",
                "ThespianManagement/Get",
                new { controller = "ThespianManagement", action = "GetThespianForUpdateOrDelete" }
            );
        }
    }
}