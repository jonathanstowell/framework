using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.ProjectHollywood.Thespian.List.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Validations.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
               AllTypes
                   .FromThisAssembly()
                   .BasedOn(typeof(IValidator<>))
                   .Configure(x => x.LifeStyle.Transient),
               AllTypes.FromThisAssembly().BasedOn<IThespianListThespianValidatorResolver>().Configure(
                   component =>
                   {
                       component.Named(component.Implementation.Name);
                       component.LifeStyle.Is(LifestyleType.Transient);
                   }).WithService.Base());
        }
    }
}
