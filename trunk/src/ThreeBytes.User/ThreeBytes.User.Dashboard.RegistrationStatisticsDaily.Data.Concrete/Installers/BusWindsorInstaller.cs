using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IDashboardRegistrationStatisticsDailyDatabaseFactory>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IDashboardRegistrationStatisticsDailyUnitOfWork>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IDashboardDailyRegistrationRepository>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IProvideDashboardRegistrationStatisticsDailySessionFactoryInitialisation>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base()
            );
        }
    }
}
