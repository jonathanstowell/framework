using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.Logging.Exceptions.List.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "ExceptionList",
                "Exception/List",
                new { controller = "ExceptionList", action = "List" }
            );

            routes.MapRoute(
                "ExceptionGetNewerThan",
                "Exception/GetNewerThan/{datetime}",
                new { controller = "ExceptionList", action = "GetNewerThan", datetime = "" }
            );
        }
    }
}