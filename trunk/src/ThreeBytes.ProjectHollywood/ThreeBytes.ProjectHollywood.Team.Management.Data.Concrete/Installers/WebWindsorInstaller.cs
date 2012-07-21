using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.ProjectHollywood.Team.Management.Data.Abstract;
using ThreeBytes.ProjectHollywood.Team.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Team.Management.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<ITeamManagementDatabaseFactory>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<ITeamManagementUnitOfWork>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<ITeamManagementEmployeeRepository>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IProvideTeamManagementSessionFactoryInitialisation>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Singleton);
                    }).WithService.Base()
            );
        }
    }
}
