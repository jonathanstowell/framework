using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor;
using ThreeBytes.Core.Plugin.Abstract;
using ThreeBytes.Core.Plugin.Concrete;
using ThreeBytes.Core.Quartz.Abstract;
using ThreeBytes.Core.Quartz.Concrete;
using ThreeBytes.User.JobHost.Installers;
using Topshelf;

namespace ThreeBytes.User.JobHost
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
                    s.SetServiceName("ThreeBytes.User.JobHost");
                    s.ConstructUsing(builder => new QuartzServer((IWindsorContainer)Bootstrapper.Container));
                    s.WhenStarted(server => server.Start());
                    s.WhenPaused(server => server.Pause());
                    s.WhenContinued(server => server.Resume());
                    s.WhenStopped(server => server.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("ThreeBytes User Quartz Service");
                x.SetDisplayName("ThreeBytes User Quartz Service");
                x.SetServiceName("ThreeBytes User Quartz Service");
            });

            host.Run();
        }
    }
}
