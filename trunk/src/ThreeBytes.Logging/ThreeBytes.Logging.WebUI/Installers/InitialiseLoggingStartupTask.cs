using System;
using Bootstrap.Extensions.StartupTasks;

namespace ThreeBytes.Logging.WebUI.Installers
{
    public class InitialiseLoggingStartupTask : IStartupTask
    {
        public void Run()
        {
            //GlobalFilters.Filters.Add(new HandleErrorWithNServiceBus(Bootstrapper.ContainerExtension.Resolve<IBus>()));
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}