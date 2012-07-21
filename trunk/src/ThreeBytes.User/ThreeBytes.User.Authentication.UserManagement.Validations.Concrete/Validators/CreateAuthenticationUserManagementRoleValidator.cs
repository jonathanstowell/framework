using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Validators
{
    public class CreateAuthenticationUserManagementRoleValidator : AbstractValidator<AuthenticationUserManagementRole>
    {
        private readonly IAuthenticationUserManagementRoleService service;

        public CreateAuthenticationUserManagementRoleValidator(IAuthenticationUserManagementRoleService service)
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

        private bool NotExist(AuthenticationUserManagementRole role)
        {
            return !service.Exists(role.Name, role.ApplicationName);
        }
    }
}
