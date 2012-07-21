using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators
{
    public class UpdateLoginRoleValidator : AbstractValidator<LoginRole>
    {
        private readonly ILoginRoleService service;

        public UpdateLoginRoleValidator(ILoginRoleService service)
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

        private bool NotExist(LoginRole role)
        {
            return !service.Exists(role.Name, role.ApplicationName);
        }
    }
}
