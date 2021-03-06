using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Password.Validations.Abstract;
using ThreeBytes.User.Authentication.Password.Validations.Concrete.Resolvers;

namespace ThreeBytes.User.Authentication.Password.Validations.Concrete.Installers
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
               Component.For<IPasswordManagementUserValidatorResolver>().ImplementedBy<PasswordManagementUserValidatorResolver>().LifeStyle.Transient);
        }
    }
}
