using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.Windsor;
using ThreeBytes.Caching.JobHost.Installers;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor;
using ThreeBytes.Core.Plugin.Abstract;
using ThreeBytes.Core.Plugin.Concrete;
using ThreeBytes.Core.Quartz.Abstract;
using ThreeBytes.Core.Quartz.Concrete;
using Topshelf;

namespace ThreeBytes.Caching.JobHost
{
    public static class JobServiceHost
    {
        public static IResolveAssemblies AssemblyResolver = new ResolveAssemblies("Plugins", "ThreeBytes.*.dll");

        public static void Main(string[] args)
        {
            Bootstrapper.With.Windsor(AssemblyResolver, BootstrapEnvironment.BUS).And.StartupTasks().UsingThisExecutionOrder(s => s
                        .First<AppDomainAssemblyResolverStartupTask>()
                        .Then<WindsorSetupStartupTask>()
                        .Then().TheRest()).Start();

            Host host = HostFactory.New(x =>
            {
                x.Service<IQuartzServer>(s =>
                {
                    s.SetServiceName("ThreeBytes.Caching.JobHost");
                    s.ConstructUsing(builder => new QuartzServer((IWindsorContainer)Bootstrapper.Container));
                    s.WhenStarted(server => server.Start());
                    s.WhenPaused(server => server.Pause());
                    s.WhenContinued(server => server.Resume());
                    s.WhenStopped(server => server.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("ThreeBytes Caching Quartz Service");
                x.SetDisplayName("ThreeBytes Caching Quartz Service");
                x.SetServiceName("ThreeBytes Caching Quartz Service");
            });

            host.Run();
        }
    }
}
