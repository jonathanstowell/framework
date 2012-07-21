using System;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.Windsor;
using ThreeBytes.Core.Plugin.Navigation.Abstract;
using ThreeBytes.Core.Plugin.Navigation.Concrete;

namespace ThreeBytes.ProjectHollywood.WebUI.Installers
{
    public class SetupNavigationStartupTask : IStartupTask
    {
        public void Run()
        {
            IProvideNavigationTree navigation = new ProvideNavigation((IWindsorContainer)Bootstrapper.Container);
            Bootstrapper.ContainerExtension.Register(navigation);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}