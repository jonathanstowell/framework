using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Data.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IDashboardLoginStatisticsYearlyDatabaseFactory>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IDashboardLoginStatisticsYearlyUnitOfWork>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IDashboardLoginStatisticsYearlyRepository>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IProvideDashboardLoginStatisticsYearlySessionFactoryInitialisation>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base()
            );
        }
    }
}
