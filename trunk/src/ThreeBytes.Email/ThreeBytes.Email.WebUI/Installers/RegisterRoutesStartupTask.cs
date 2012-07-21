using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;

namespace ThreeBytes.Email.WebUI.Installers
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