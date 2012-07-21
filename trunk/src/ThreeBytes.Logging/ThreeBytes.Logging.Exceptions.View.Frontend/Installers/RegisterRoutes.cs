using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.Logging.Exceptions.View.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "ExceptionDetails",
                "Exception/Details/{id}",
                new { controller = "ExceptionView", action = "Details", id = "" }
            );
        }
    }
}