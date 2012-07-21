using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IDashboardRegistrationStatisticsQuarterlyDatabaseFactory>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IDashboardRegistrationStatisticsQuarterlyUnitOfWork>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IDashboardRegistrationStatisticsQuarterlyRepository>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IProvideDashboardRegistrationStatisticsQuarterlySessionFactoryInitialisation>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base()
            );
        }
    }
}
