using System;
using Bootstrap.Extensions.StartupTasks;

namespace ThreeBytes.ProjectHollywood.Team.ServiceHost.Installers
{
    public class AppDomainAssemblyResolverStartupTask : IStartupTask
    {
        public void Run()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (a, args) => EndpointConfig.AssemblyResolver.GetAssembly(args.Name);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
