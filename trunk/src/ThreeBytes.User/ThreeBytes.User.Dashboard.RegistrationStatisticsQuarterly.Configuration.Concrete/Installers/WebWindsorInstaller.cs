using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Configuration.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Configuration.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
             container.Register(
                AllTypes.FromThisAssembly().BasedOn<IProvideRegistrationStatisticsQuarterlyConfiguration>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Singleton);
                    }).WithService.Base()
            );
        }
    }
}
