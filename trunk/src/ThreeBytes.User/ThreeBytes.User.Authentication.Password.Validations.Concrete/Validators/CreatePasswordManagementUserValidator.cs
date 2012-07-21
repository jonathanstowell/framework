using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Password.Validations.Concrete.Validators
{
    public class CreatePasswordManagementUserValidator : AbstractValidator<PasswordManagementUser>
    {
        private readonly IPasswordManagementUserService service;

        public CreatePasswordManagementUserValidator(IPasswordManagementUserService service, IProvideUserConfiguration provideUserConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");

            RuleFor(x => x.Username)
                    .NotEmpty().WithMessage(Resources.Resources.RequiredUsernameValidationMessage)
                    .Must((user, name) => UniqueUsername(user)).WithMessage(Resources.Resources.UniqueUsernameValidationMessage);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(Resources.Resources.UnqiueEmailValidationMessage);

            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage(Resources.Resources.RequiredApplicationNameValidationMessage)
                .Length(1, 20).WithMessage(string.Format(Resources.Resources.LengthApplicationNameValidationMessage, 1, 20));

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Length(provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength)
                .Equal(user => user.Password).WithMessage("Passwords must match.");
        }

        private bool UniqueUsername(PasswordManagementUser user)
        {
            return service.UniqueUsername(user.Username, user.ApplicationName);
        }

        private bool UniqueEmail(PasswordManagementUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }
    }
}
