using System;
using FluentValidation;
using ThreeBytes.User.Role.View.Entities;
using ThreeBytes.User.Role.View.Service.Abstract;

namespace ThreeBytes.User.Role.View.Validations.Concrete.Validators
{
    public class CreateRoleViewRoleValidator : AbstractValidator<RoleViewRole>
    {
        private readonly IRoleViewRoleService service;

        public CreateRoleViewRoleValidator(IRoleViewRoleService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 20).WithMessage("'Name' must be a string with a maximum length of 20.")
                .Must((role, name) => NotExist(role)).WithMessage(Resources.Resources.UniqueRoleValidationMessage);

            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage("'Application Name' must be a string with a maximum length of 20.")
                .Length(1, 20).WithMessage(string.Format(Resources.Resources.LengthApplicationNameValidationMessage, 1, 20));
        }

        private bool NotExist(RoleViewRole role)
        {
            return !service.Exists(role.ItemId, role.Name, role.ApplicationName);
        }
    }
}
