using System;
using Bootstrap.Extensions.StartupTasks;

namespace ThreeBytes.ProjectHollywood.WebUI.Installers
{
    public class AppDomainAssemblyResolverStartupTask : IStartupTask
    {
        public void Run()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (a, args) => MvcApplication.AssemblyResolver.GetAssembly(args.Name);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}