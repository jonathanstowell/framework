using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Validations.Concrete.Validators
{
    public class UpdateAuthenticationUserViewUserEmailValidator : AbstractValidator<AuthenticationUserViewUser>
    {
        private readonly IAuthenticationUserViewUserService service;

        public UpdateAuthenticationUserViewUserEmailValidator(IAuthenticationUserViewUserService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(
                    Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(
                    Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(
                    Resources.Resources.UnqiueEmailValidationMessage);
        }

        private bool UniqueEmail(AuthenticationUserViewUser user)
        {
            return service.UniqueEmail(user.ItemId, user.Email, user.ApplicationName);
        }
    }
}