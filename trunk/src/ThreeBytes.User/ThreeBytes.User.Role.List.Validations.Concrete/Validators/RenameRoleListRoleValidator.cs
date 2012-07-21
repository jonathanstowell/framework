using System;
using FluentValidation;
using ThreeBytes.User.Role.List.Entities;
using ThreeBytes.User.Role.List.Service.Abstract;

namespace ThreeBytes.User.Role.List.Validations.Concrete.Validators
{
    public class RenameRoleListRoleValidator : AbstractValidator<RoleListRole>
    {
        private readonly IRoleListRoleService service;

        public RenameRoleListRoleValidator(IRoleListRoleService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            RuleFor(x => x).NotNull().WithName("General").WithMessage("Role does not exist");
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 20).WithMessage("'Name' must be a string with a maximum length of 20.")
                .Must((role, name) => NotExist(role)).WithMessage(Resources.Resources.UniqueRoleValidationMessage);
        }

        private bool NotExist(RoleListRole role)
        {
            return !service.Exists(role.Name, role.ApplicationName);
        }
    }
}
