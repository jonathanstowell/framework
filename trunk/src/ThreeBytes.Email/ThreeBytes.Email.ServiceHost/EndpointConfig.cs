using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.Windsor;
using NServiceBus;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor;
using ThreeBytes.Core.Plugin.Abstract;
using ThreeBytes.Core.Plugin.Concrete;
using ThreeBytes.Email.ServiceHost.Installers;

namespace ThreeBytes.Email.ServiceHost
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        public static IResolveAssemblies AssemblyResolver = new ResolveAssemblies("Plugins", "ThreeBytes.*.dll");
        private static IWindsorContainer Container = new WindsorContainer();

        public EndpointConfig()
        {
            Bootstrapper.With.Windsor(AssemblyResolver, BootstrapEnvironment.BUS).And.StartupTasks().UsingThisExecutionOrder(s => s
                        .First<AppDomainAssemblyResolverStartupTask>()
                        .Then<WindsorSetupStartupTask>()
                        .Then().TheRest()).Start();
        }

        public void Init()
        {
            var assemblies = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)
                                        .GetFiles("NServiceBus*.dll", SearchOption.AllDirectories)
                                        .Select(file => Assembly.LoadFrom(file.FullName));

            Container = (IWindsorContainer)Bootstrapper.Container;

            Configure.With(assemblies.Concat(AssemblyResolver.PluginAssembliesByFullName.Values))
                .CastleWindsorBuilder(Container)
                .MsmqTransport()
                .MsmqSubscriptionStorage()
                .XmlSerializer()
                .DisableTimeoutManager();
        }
    }
}
