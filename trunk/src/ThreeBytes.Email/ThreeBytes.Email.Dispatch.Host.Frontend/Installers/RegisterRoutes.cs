using System.Web.Mvc;
using System.Web.Routing;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.Email.Dispatch.Host.Frontend.Installers
{
    public class RegisterRoutes : IRegisterRoutes
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "DispatchIndex",
                "Dispatch",
                new { controller = "EmailDispatchHost", action = "Index" }
            );
        }
    }
}