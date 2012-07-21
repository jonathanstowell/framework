using System;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using ThreeBytes.Core.Castle.Windsor.SubResolvers;

namespace ThreeBytes.Email.JobHost.Installers
{
    public class WindsorSetupStartupTask : IStartupTask
    {
        public void Run()
        {
            ((IWindsorContainer)Bootstrapper.Container).Kernel.Resolver.AddSubResolver(new CollectionResolver(((IWindsorContainer)Bootstrapper.Container).Kernel, true));
            ((IWindsorContainer)Bootstrapper.Container).Kernel.Resolver.AddSubResolver(new AutoFactoryResolver(((IWindsorContainer)Bootstrapper.Container).Kernel));
            ((IWindsorContainer)Bootstrapper.Container).Kernel.AddFacility<FactorySupportFacility>();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}