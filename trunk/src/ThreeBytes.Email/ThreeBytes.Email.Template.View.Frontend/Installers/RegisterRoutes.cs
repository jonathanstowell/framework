using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.Email.Template.View.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "TemplateDetails",
                "Template/Details",
                new { controller = "EmailTemplateView", action = "Details" }
            );

            routes.MapRoute(
                "TemplateViewGetDetailsNoPageParams",
                "Template/GetDetails",
                new { controller = "EmailTemplateView", action = "GetDetails" }
            );

            routes.MapRoute(
                "TemplateViewGetDetails",
                "Template/GetDetails/{id}",
                new { controller = "EmailTemplateView", action = "GetDetails", id = UrlParameter.Optional }
            );
        }
    }
}