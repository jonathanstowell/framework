using System;
using Bootstrap.Extensions.StartupTasks;
using ThreeBytes.Core.Logging;

namespace ThreeBytes.Email.ServiceHost.Installers
{
    public class AppDomainUnhandledExceptionLoggingStartupTask : IStartupTask
    {
        public void Run()
        {
            log4net.Config.XmlConfigurator.Configure();
            AppDomain.CurrentDomain.UnhandledException += ConsoleLogger.UnhandledExceptionTrapper;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
