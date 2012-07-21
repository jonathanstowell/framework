using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.Email.Template.List.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "TemplateList",
                "Template/List",
                new { controller = "EmailTemplateList", action = "List" }
            );

            routes.MapRoute(
                "TemplateListGetPageParams",
                "Template/GetPage",
                new { controller = "EmailTemplateList", action = "GetPage" }
            );

            routes.MapRoute(
                "TemplateListGetPage",
                "Template/GetPage/{page}/{datetime}",
                new { controller = "EmailTemplateList", action = "GetPage", page = "", datetime = "" }
            );

            routes.MapRoute(
                "TemplateListGet",
                "Template/List/Get/{id}",
                new { controller = "EmailTemplateList", action = "Get", id = "" }
            );

            routes.MapRoute(
                "TemplateListGetNewerThanPageParams",
                "Template/List/GetNewerThan",
                new { controller = "EmailTemplateList", action = "GetNewerThan" }
            );

            routes.MapRoute(
                "TemplateListGetNewerThan",
                "Template/List/GetNewerThan/{datetime}",
                new { controller = "EmailTemplateList", action = "GetNewerThan", datetime = "" }
            );
        }
    }
}