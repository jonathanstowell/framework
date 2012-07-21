using FluentValidation;
using ThreeBytes.User.Role.View.Entities;

namespace ThreeBytes.User.Role.View.Validations.Abstract
{
    public interface IRoleViewRoleValidatorResolver
    {
        IValidator<RoleViewRole> CreateValidator();
        IValidator<RoleViewRole> RenameValidator();
    }
}
