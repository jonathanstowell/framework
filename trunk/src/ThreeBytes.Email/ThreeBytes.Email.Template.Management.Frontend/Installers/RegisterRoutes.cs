using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.Email.Template.Management.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "TemplateCreate",
                "Template/Create",
                new { controller = "EmailTemplateManagement", action = "Create" }
            );

            routes.MapRoute(
                "TemplateEditPageParams",
                "Template/Edit",
                new { controller = "EmailTemplateManagement", action = "Edit" }
            );

            routes.MapRoute(
                "TemplateEdit",
                "Template/Edit/{id}",
                new { controller = "EmailTemplateManagement", action = "Edit", id = "" }
            );

            routes.MapRoute(
                "TemplateRename",
                "Template/Rename",
                new { controller = "EmailTemplateManagement", action = "RenameName" }
            );

            routes.MapRoute(
                "TemplateRenameFromAddress",
                "Template/RenameFromAddress",
                new { controller = "EmailTemplateManagement", action = "RenameFrom" }
            );

            routes.MapRoute(
                "TemplateUpdateContent",
                "Template/Update",
                new { controller = "EmailTemplateManagement", action = "UpdateContent" }
            );

            routes.MapRoute(
                "TemplateDelete",
                "Template/Delete/{id}",
                new { controller = "EmailTemplateManagement", action = "Delete", id = "" }
            );

            routes.MapRoute(
                "TemplateManagementGet",
                "TemplateManagement/Get",
                new { controller = "EmailTemplateManagement", action = "GetTemplateForUpdateOrDelete" }
            );
        }
    }
}