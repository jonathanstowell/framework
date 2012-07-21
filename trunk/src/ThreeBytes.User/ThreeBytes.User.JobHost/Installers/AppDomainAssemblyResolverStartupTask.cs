using System;
using Bootstrap.Extensions.StartupTasks;

namespace ThreeBytes.User.JobHost.Installers
{
    public class AppDomainAssemblyResolverStartupTask : IStartupTask
    {
        public void Run()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (a, args) => JobServiceHost.AssemblyResolver.GetAssembly(args.Name);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
