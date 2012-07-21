using Bootstrap.Windsor;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ThreeBytes.ProjectHollywood.Configuration.Abstract;
using ThreeBytes.ProjectHollywood.Configuration.Abstract.Paging;

namespace ThreeBytes.ProjectHollywood.Configuration.Concrete.Installers
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IProvidePagingSettings>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Singleton);
                    }).WithService.Base());

            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IProjectHollywoodConfiguration>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Singleton);
                    }).WithService.Base());
        }
    }
}
