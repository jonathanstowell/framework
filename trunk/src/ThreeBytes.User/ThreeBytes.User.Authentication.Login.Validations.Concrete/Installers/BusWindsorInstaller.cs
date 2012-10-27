using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Concrete.Resolvers;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Installers
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
               Component.For<ILoginRoleValidatorResolver>().ImplementedBy<LoginRoleValidatorResolver>().LifeStyle.Transient,
               Component.For<ILoginUserValidatorResolver>().ImplementedBy<LoginUserValidatorResolver>().LifeStyle.Transient);
        }
    }
}
