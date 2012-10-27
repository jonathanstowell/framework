using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.ProjectHollywood.Host.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Host.Validations.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
               AllTypes
                   .FromThisAssembly()
                   .BasedOn(typeof(IValidator<>))
                   .Configure(x => x.LifeStyle.Transient),
                AllTypes.FromThisAssembly().BasedOn<IPersistImageValidatorResolver>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Transient);
                    }).WithService.Base());
        }
    }
}
