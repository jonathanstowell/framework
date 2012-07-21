using System;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using ThreeBytes.Core.Quartz.Concrete;

namespace ThreeBytes.Caching.JobHost.Installers
{
    public class QuartzStartupTask : IStartupTask
    {
        public void Run()
        {
            ((IWindsorContainer)Bootstrapper.Container).Kernel.Register(
                    Component.For<IServiceLocator>().Instance(new WindsorServiceLocator((IWindsorContainer)Bootstrapper.Container)),
                    Component.For<IJobFactory>().ImplementedBy<WindsorJobFactory>(),
                    Component.For<ISchedulerFactory>().ImplementedBy<StdSchedulerFactory>(),
                    Component.For<IScheduler>().UsingFactory((ISchedulerFactory factory) => factory.GetScheduler())
                );
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
