using System;
using Bootstrap.Extensions.Containers;
using Bootstrap.Windsor;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Plugin.Abstract;

namespace ThreeBytes.Core.Bootstrapper.Extensions.Windsor
{
    public class ThreeBytesWindsorExtension : WindsorExtension
    {
        private readonly IResolveAssemblies assemblyResolver;
        public BootstrapEnvironment BootstrapEnvironment { get; set; }

        public ThreeBytesWindsorExtension(IResolveAssemblies assemblyResolver, BootstrapEnvironment bootstrapEnvironment, IRegistrationHelper registrationHelper)
            : base(registrationHelper)
        {
            if (assemblyResolver == null)
                throw new ArgumentNullException("assemblyResolver");

            this.assemblyResolver = assemblyResolver;
            BootstrapEnvironment = bootstrapEnvironment;
        }

        protected override void RegisterImplementationsOfIRegistration()
        {
            base.RegisterImplementationsOfIRegistration();

            if (BootstrapEnvironment.Equals(BootstrapEnvironment.WEB))
                RegisterAll<IWebWindsorRegistration>();
            else if (BootstrapEnvironment.Equals(BootstrapEnvironment.BUS))
                RegisterAll<IBusWindsorRegistration>();

        }

        protected override void InvokeRegisterForImplementationsOfIRegistration()
        {
            base.InvokeRegisterForImplementationsOfIRegistration();

            if (BootstrapEnvironment.Equals(BootstrapEnvironment.WEB))
                ((IWindsorContainer)Container).ResolveAll<IWebWindsorRegistration>().ForEach<IWebWindsorRegistration>(r => r.Install(((IWindsorContainer)Container)));
            else if (BootstrapEnvironment.Equals(BootstrapEnvironment.BUS))
                ((IWindsorContainer)Container).ResolveAll<IBusWindsorRegistration>().ForEach<IBusWindsorRegistration>(r => r.Install(((IWindsorContainer)Container)));
        }

        public override void RegisterAll<TTarget>()
        {
            base.RegisterAll<TTarget>();

            if (assemblyResolver != null)
            {
                assemblyResolver.PluginAssembliesByFullName.Values.ForEach(a => ((IWindsorContainer)Container).Register(new IRegistration[] { AllTypes.FromAssembly(a).BasedOn<TTarget>().WithService.Base() }));
            }
        }
    }
}
