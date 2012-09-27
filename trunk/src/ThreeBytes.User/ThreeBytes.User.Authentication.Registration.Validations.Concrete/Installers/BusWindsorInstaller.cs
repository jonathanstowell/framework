using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Registration.Validations.Abstract;
using ThreeBytes.User.Authentication.Registration.Validations.Concrete.Resolvers;

namespace ThreeBytes.User.Authentication.Registration.Validations.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
               AllTypes
                   .FromThisAssembly()
                   .BasedOn(typeof(IValidator<>))
                   .LifestyleTransient(),
               Component.For<IRegistrationUserValidatorResolver>().ImplementedBy<RegistrationUserValidatorResolver>().LifeStyle.Transient,
               Component.For<IExternalUserValidatorResolver>().ImplementedBy<ExternalUserValidatorResolver>().LifeStyle.Transient);
        }
    }
}
