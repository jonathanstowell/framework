using System;
using System.Collections.Generic;
using System.Linq;
using Bootstrap.Extensions.Containers;
using Castle.Core;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Plugin.Abstract;

namespace ThreeBytes.Core.Bootstrapper.Extensions.Windsor
{
    public class WindsorExtension : BootstrapperContainerExtension
    {
        private IWindsorContainer container;
        private readonly IResolveAssemblies assemblyResolver;

        public IBootstrapperContainerExtensionOptions Options { get; private set; }
        public BootstrapEnvironment BootstrapEnvironment { get; set; }

        public WindsorExtension()
        {
            Options = new BootstrapperContainerExtensionOptions();
            Bootstrap.Bootstrapper.Excluding.Assembly("Castle");
        }

        public WindsorExtension(IResolveAssemblies assemblyResolver, BootstrapEnvironment bootstrapEnvironment)
            : this()
        {
            if (assemblyResolver == null)
                throw new ArgumentNullException("assemblyResolver");

            this.assemblyResolver = assemblyResolver;
            BootstrapEnvironment = bootstrapEnvironment;
        }

        protected override void InitializeContainer()
        {
            container = new WindsorContainer().AddFacility<FactorySupportFacility>();
            Container = container;
        }

        protected override void RegisterImplementationsOfIRegistration()
        {
            CheckContainer();

            if (Options.AutoRegistration)
            {
                AutoRegister();
            }

            RegisterAll<IBootstrapperRegistration>();

            if (BootstrapEnvironment.Equals(BootstrapEnvironment.WEB))
                RegisterAll<IWebWindsorRegistration>();
            else if (BootstrapEnvironment.Equals(BootstrapEnvironment.BUS))
                RegisterAll<IBusWindsorRegistration>();

        }

        protected override void InvokeRegisterForImplementationsOfIRegistration()
        {
            CheckContainer();

            container.ResolveAll<IBootstrapperRegistration>().ForEach<IBootstrapperRegistration>(r => r.Register(this));

            if (BootstrapEnvironment.Equals(BootstrapEnvironment.WEB))
                container.ResolveAll<IWebWindsorRegistration>().ForEach<IWebWindsorRegistration>(r => r.Install(container));
            else if (BootstrapEnvironment.Equals(BootstrapEnvironment.BUS))
                container.ResolveAll<IBusWindsorRegistration>().ForEach<IBusWindsorRegistration>(r => r.Install(container));
        }

        protected override void ResetContainer()
        {
            container = null;
            Container = null;
        }

        public override void RegisterAll<TTarget>()
        {
            CheckContainer();

            RegistrationHelper.GetAssemblies().ToList().ForEach(
                a => container.Register(new IRegistration[] { AllTypes.FromAssembly(a).BasedOn<TTarget>().WithService.Base() }));

            if (assemblyResolver != null)
            {
                assemblyResolver.PluginAssembliesByFullName.Values.ForEach(
                    a =>
                    container.Register(new IRegistration[] { AllTypes.FromAssembly(a).BasedOn<TTarget>().WithService.Base() }));
            }
        }

        public override void SetServiceLocator()
        {
            CheckContainer();
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

        }

        public override void ResetServiceLocator()
        {
            ServiceLocator.SetLocatorProvider(() => null);
        }

        public override T Resolve<T>()
        {
            CheckContainer();
            return container.Resolve<T>();
        }

        public override IList<T> ResolveAll<T>()
        {
            CheckContainer();
            return container.ResolveAll<T>();
        }

        public override void Register<TTarget, TImplementation>()
        {
            CheckContainer();

            if (!container.Kernel.HasComponent(typeof(TTarget).Name) || (container.Resolve<TTarget>().GetType() != typeof(TImplementation)))
            {
                container.Register(new IRegistration[] { Component.For<TTarget>().ImplementedBy<TImplementation>() });
            }
        }

        public override void Register<TTarget>(TTarget implementation)
        {
            CheckContainer();

            if (!container.Kernel.HasComponent(typeof(TTarget).Name) || (container.Resolve<TTarget>().GetType() != implementation.GetType()))
            {
                container.Register(new IRegistration[] { Component.For<TTarget>().Instance(implementation) });
            }
        }
    }
}
