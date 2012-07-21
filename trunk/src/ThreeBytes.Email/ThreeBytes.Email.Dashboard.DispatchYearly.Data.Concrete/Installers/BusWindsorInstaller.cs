using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Email.Dashboard.DispatchYearly.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchYearly.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Data.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IDispatchYearlyDashboardDatabaseFactory>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IDispatchYearlyDashboardUnitOfWork>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IProvideDispatchYearlyDashboardSessionFactoryInitialisation>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IDispatchYearlyDashboardRepository>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base()
            );
        }
    }
}
