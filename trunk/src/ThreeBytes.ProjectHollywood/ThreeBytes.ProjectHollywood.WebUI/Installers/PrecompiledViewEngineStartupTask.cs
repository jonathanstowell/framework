using System;
using System.Linq;
using System.Web.Mvc;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.Windsor;
using ThreeBytes.Core.Web.Mvc.PrecompiledViewEngine;

namespace ThreeBytes.ProjectHollywood.WebUI.Installers
{
    public class PrecompiledViewEngineStartupTask : IStartupTask
    {
        public void Run()
        {
            var engine = new WindsorPrecompiledViewEngine((IWindsorContainer)Bootstrapper.Container);
            ViewEngines.Engines.Add(engine);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}