using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators
{
    public class UpdateLoginUserEmailAddressValidator : AbstractValidator<LoginUser>
    {
        private readonly ILoginUserService service;

        public UpdateLoginUserEmailAddressValidator(ILoginUserService service, IProvideUserConfiguration provideUserConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            this.service = service;

            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(Resources.Resources.UnqiueEmailValidationMessage);
        }

        private bool UniqueEmail(LoginUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }
    }
}