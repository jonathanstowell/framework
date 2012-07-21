using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators
{
    public class UpdatePasswordLoginUserValidator : AbstractValidator<LoginUser>
    {
        public UpdatePasswordLoginUserValidator(IProvideUserConfiguration provideUserConfiguration)
        {
            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage(Resources.Resources.RequiredPasswordValidationMessage)
                 .Length(provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength).WithMessage(string.Format(Resources.Resources.LengthPasswordValidationMessage, provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength));
        }
    }
}
