using System.Web.Routing;

namespace ThreeBytes.Core.Bootstrapper.Extensions.Mvc
{
    public interface IRegisterRoutes
    {
        void Register(RouteCollection routes);
    }
}
