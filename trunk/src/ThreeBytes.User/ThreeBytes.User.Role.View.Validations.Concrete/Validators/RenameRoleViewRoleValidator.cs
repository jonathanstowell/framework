using System;
using FluentValidation;
using ThreeBytes.User.Role.View.Entities;
using ThreeBytes.User.Role.View.Service.Abstract;

namespace ThreeBytes.User.Role.View.Validations.Concrete.Validators
{
    public class RenameRoleViewRoleValidator : AbstractValidator<RoleViewRole>
    {
        private readonly IRoleViewRoleService service;

        public RenameRoleViewRoleValidator(IRoleViewRoleService service)
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

        private bool NotExist(RoleViewRole role)
        {
            return !service.Exists(role.ItemId, role.Name, role.ApplicationName);
        }
    }
}
