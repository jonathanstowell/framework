using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "NewsManagementCreate",
                "News/Create",
                new { controller = "NewsManagement", action = "Create" }
            );

            routes.MapRoute(
                "NewsManagementEdit",
                "News/Edit",
                new { controller = "NewsManagement", action = "Edit" }
            );

            routes.MapRoute(
                "NewsManagementRenameTitle",
                "News/RenameTitle",
                new { controller = "NewsManagement", action = "RenameTitle" }
            );

            routes.MapRoute(
                "NewsManagementUpdateContent",
                "News/UpdateContent",
                new { controller = "NewsManagement", action = "UpdateContent" }
            );

            routes.MapRoute(
                "NewsManagementDelete",
                "News/Delete",
                new { controller = "NewsManagement", action = "Delete"}
            );

            routes.MapRoute(
                "NewsManagementGet",
                "NewsManagement/Get",
                new { controller = "NewsManagement", action = "GetNewsArticleForUpdateOrDelete" }
            );
        }
    }
}