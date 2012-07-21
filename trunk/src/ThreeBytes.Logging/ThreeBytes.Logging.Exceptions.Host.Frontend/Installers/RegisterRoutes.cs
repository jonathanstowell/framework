using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.Logging.Exceptions.Host.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "LoggingExceptionsIndex",
                "Exceptions",
                new { controller = "LoggingExceptionsHost", action = "Index" }
            );
        }
    }
}