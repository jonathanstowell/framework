using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.ProjectHollywood.News.View.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "NewsViewDetails",
                "News/Details",
                new { controller = "NewsView", action = "Details" }
            );

            routes.MapRoute(
                "NewsViewGetDetails",
                "News/GetDetails/{id}",
                new { controller = "NewsView", action = "GetDetails", id = "" }
            );
        }
    }
}