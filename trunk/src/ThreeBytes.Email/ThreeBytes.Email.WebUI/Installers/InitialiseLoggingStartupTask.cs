using System;
using System.Web.Mvc;
using Bootstrap.Extensions.StartupTasks;
using ThreeBytes.Core.Logging;

namespace ThreeBytes.Email.WebUI.Installers
{
    public class InitialiseLoggingStartupTask : IStartupTask
    {
        public void Run()
        {
            log4net.Config.XmlConfigurator.Configure();
            GlobalFilters.Filters.Add(new HandleErrorUsingLogger());
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}