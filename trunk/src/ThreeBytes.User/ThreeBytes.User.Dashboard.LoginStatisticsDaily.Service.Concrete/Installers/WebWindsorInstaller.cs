using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Service.Abstract;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Service.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IDashboardLoginStatisticsDailyService>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.PerWebRequest);
                    }).WithService.Base());
        }
    }
}
