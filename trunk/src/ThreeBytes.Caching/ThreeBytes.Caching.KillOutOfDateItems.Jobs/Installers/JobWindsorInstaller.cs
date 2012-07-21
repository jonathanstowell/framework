using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Quartz;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Quartz.Abstract;

namespace ThreeBytes.Caching.KillOutOfDateItems.Jobs.Installers
{
    public class JobWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IJob>().Configure(component => component.LifeStyle.Is(LifestyleType.Transient)),
                AllTypes.FromThisAssembly().BasedOn<IRegisterQuartzJob>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Transient);
                    }).WithService.Base()
            );
        }
    }
}
