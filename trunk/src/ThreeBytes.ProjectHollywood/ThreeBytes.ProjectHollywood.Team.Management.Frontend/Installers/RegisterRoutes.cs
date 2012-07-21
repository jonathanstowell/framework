using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "TeamManagementCreate",
                "Team/Create",
                new { controller = "TeamManagement", action = "Create" }
            );

            routes.MapRoute(
                "TeamManagementEdit",
                "Team/Edit",
                new { controller = "TeamManagement", action = "Edit" }
            );

            routes.MapRoute(
                "TeamManagementRename",
                "Team/Rename",
                new { controller = "TeamManagement", action = "Rename" }
            );

            routes.MapRoute(
                "TeamManagementRenameJobTitle",
                "Team/RenameJobTitle",
                new { controller = "TeamManagement", action = "RenameJobTitle" }
            );

            routes.MapRoute(
                "TeamManagementUpdateSummary",
                "Team/UpdateSummary",
                new { controller = "TeamManagement", action = "UpdateSummary" }
            );

            routes.MapRoute(
                "TeamManagementUpdateProfileImage",
                "Team/UpdateProfileImage",
                new { controller = "TeamManagement", action = "UpdateProfileImage" }
            );

            routes.MapRoute(
                "TeamManagementDelete",
                "Team/Delete",
                new { controller = "TeamManagement", action = "Delete" }
            );

            routes.MapRoute(
                "TeamManagementGet",
                "TeamManagement/Get",
                new { controller = "TeamManagement", action = "GetTeamEmployeeForUpdateOrDelete" }
            );
        }
    }
}