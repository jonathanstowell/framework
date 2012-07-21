using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.ProjectHollywood.News.List.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "NewsList",
                "News/List",
                new { controller = "NewsList", action = "List" }
            );

            routes.MapRoute(
                "NewsListGetPageParams",
                "News/GetPage",
                new { controller = "NewsList", action = "GetPage" }
            );

            routes.MapRoute(
                "NewsListGetPage",
                "News/GetPage/{page}/{datetime}",
                new { controller = "NewsList", action = "GetPage", page = "", datetime = "" }
            );

            routes.MapRoute(
                "NewsListGet",
                "News/List/Get/{id}",
                new { controller = "NewsList", action = "Get", id = "" }
            );

            routes.MapRoute(
                "NewsListGetNewerThanPageParams",
                "News/List/GetNewerThan",
                new { controller = "NewsList", action = "GetNewerThan" }
            );

            routes.MapRoute(
                "NewsListGetNewerThan",
                "News/List/GetNewerThan/{datetime}",
                new { controller = "NewsList", action = "GetNewerThan", datetime = "" }
            );
        }
    }
}