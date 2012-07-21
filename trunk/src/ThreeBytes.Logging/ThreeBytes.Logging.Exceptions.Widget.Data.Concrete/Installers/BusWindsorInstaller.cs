using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Logging.Exceptions.Widget.Data.Abstract;
using ThreeBytes.Logging.Exceptions.Widget.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.Widget.Data.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IExceptionWidgetDatabaseFactory>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IExceptionWidgetUnitOfWork>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IExceptionWidgetRepository>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Thread);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IProvideExceptionWidgetSessionFactoryInitialisation>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Singleton);
                    }).WithService.Base()
            );
        }
    }
}
