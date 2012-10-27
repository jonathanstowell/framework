using System;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SignalR;
using SignalR.Configuration;
using SignalR.Hosting.AspNet;
using SignalR.Hubs;
using SignalR.Infrastructure;
using SignalR.MessageBus;
using SignalR.Transports;
using ThreeBytes.Core.SignalR.Windsor;

namespace ThreeBytes.Logging.WebUI.Installers
{
    public class SignalRStartupTask : IStartupTask
    {
        public void Run()
        {
            var container = (IWindsorContainer)Bootstrapper.Container;
            var dependencyResolver = new WindsorDependencyResolver(container);

            container.Register(Component.For<IHubLocator>().ImplementedBy<WindsorHubLocator>());
            container.Register(Component.For<IHubFactory>().ImplementedBy<DefaultHubFactory>());
            container.Register(Component.For<IActionResolver>().ImplementedBy<DefaultActionResolver>());
            container.Register(Component.For<IHubTypeResolver>().ImplementedBy<DefaultHubTypeResolver>());
            container.Register(Component.For<IHubActivator>().ImplementedBy<DefaultHubActivator>());
            container.Register(Component.For<IMessageBus>().ImplementedBy<InProcessMessageBus>());
            container.Register(Component.For<IConnectionIdFactory>().ImplementedBy<GuidConnectionIdFactory>());
            container.Register(Component.For<ITransportManager>().ImplementedBy<TransportManager>());
            container.Register(Component.For<ITraceManager>().ImplementedBy<TraceManager>());
            container.Register(Component.For<IJavaScriptProxyGenerator>().ImplementedBy<DefaultJavaScriptProxyGenerator>());
            container.Register(Component.For<IJsonSerializer>().ImplementedBy<JsonConvertAdapter>());
            container.Register(Component.For<IDependencyResolver>().Instance(dependencyResolver));
            container.Register(Component.For<IJavaScriptMinifier>().ImplementedBy<Core.SignalR.Infrastructure.NullJavaScriptMinifier>());
            container.Register(Component.For<ITransportHeartBeat>().ImplementedBy<TransportHeartBeat>());
            container.Register(Component.For<IConnectionManager>().ImplementedBy<ConnectionManager>());
            container.Register(Component.For<IConfigurationManager>().ImplementedBy<DefaultConfigurationManager>());

            AspNetHost.SetResolver(dependencyResolver);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}