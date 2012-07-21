using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Validators
{
    public class UpdateAuthenticationUserManagementUserEmailValidator : AbstractValidator<AuthenticationUserManagementUser>
    {
        private readonly IAuthenticationUserManagementUserService service;

        public UpdateAuthenticationUserManagementUserEmailValidator(IAuthenticationUserManagementUserService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(
                    Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(
                    Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(
                    Resources.Resources.UnqiueEmailValidationMessage);
        }

        private bool UniqueEmail(AuthenticationUserManagementUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }
    }
}