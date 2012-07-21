using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentNHibernate;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Email.Dispatch.Management.Entities.Mappings.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IMappingProvider>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Singleton);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<ICacheItemConfiguration>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Singleton);
                    }).WithService.Base());
        }
    }
}
