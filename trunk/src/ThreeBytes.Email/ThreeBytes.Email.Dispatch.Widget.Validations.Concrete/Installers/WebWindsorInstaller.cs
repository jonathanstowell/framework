using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Email.Dispatch.Widget.Validations.Abstract;

namespace ThreeBytes.Email.Dispatch.Widget.Validations.Concrete.Installers
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
               AllTypes.FromThisAssembly().BasedOn<IEmailDispatchWidgetEmailMessageValidatorResolver>().Configure(
                   component =>
                   {
                       component.Named(component.Implementation.Name);
                       component.LifeStyle.Is(LifestyleType.Transient);
                   }).WithService.Base());
        }
    }
}
