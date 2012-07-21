using System;
using System.Linq;
using System.Web.Routing;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.User.WebUI.Installers
{
    public class RegisterRoutesStartupTask : IStartupTask
    {
        public void Run()
        {
            foreach (var registerRoutes in Bootstrapper.ContainerExtension.ResolveAll<IRegisterRoutes>().ToList())
            {
                registerRoutes.Register(RouteTable.Routes);
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}