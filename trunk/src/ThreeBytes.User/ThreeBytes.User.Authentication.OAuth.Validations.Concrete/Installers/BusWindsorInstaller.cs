using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.OAuth.Validations.Abstract;
using ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Resolvers;

namespace ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Installers
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
               Component.For<IOAuthRoleValidatorResolver>().ImplementedBy<OAuthRoleValidatorResolver>().LifeStyle.Transient,
               Component.For<IOAuthUserValidatorResolver>().ImplementedBy<OAuthUserValidatorResolver>().LifeStyle.Transient);
        }
    }
}
