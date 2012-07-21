using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Validations.Concrete.Validators
{
    public class CreateAuthenticationUserViewRoleValidator : AbstractValidator<AuthenticationUserViewRole>
    {
        private readonly IAuthenticationUserViewRoleService service;

        public CreateAuthenticationUserViewRoleValidator(IAuthenticationUserViewRoleService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(Resources.Resources.RequiredRoleNameValidationMessage)
                .Length(1, 20).WithMessage(string.Format(Resources.Resources.LengthRoleNameValidationMessage, 1, 20))
                .Must((role, name) => NotExist(role)).WithMessage(Resources.Resources.UniqueRoleValidationMessage);

            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage(Resources.Resources.RequiredApplicationNameValidationMessage)
                .Length(1, 20).WithMessage(string.Format(Resources.Resources.LengthApplicationNameValidationMessage, 1, 20));
        }

        private bool NotExist(AuthenticationUserViewRole role)
        {
            return !service.Exists(role.Name, role.ApplicationName);
        }
    }
}
