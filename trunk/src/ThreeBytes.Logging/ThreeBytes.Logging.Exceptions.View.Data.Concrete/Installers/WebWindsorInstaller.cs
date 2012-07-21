using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Logging.Exceptions.View.Data.Abstract;
using ThreeBytes.Logging.Exceptions.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.View.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IExceptionViewDatabaseFactory>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IExceptionViewUnitOfWork>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IExceptionViewRepository>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IProvideExceptionViewSessionFactoryInitialisation>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Singleton);
                    }).WithService.Base()
            );
        }
    }
}
