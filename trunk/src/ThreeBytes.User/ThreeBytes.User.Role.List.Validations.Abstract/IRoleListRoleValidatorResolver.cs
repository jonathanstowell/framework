using FluentValidation;
using ThreeBytes.User.Role.List.Entities;

namespace ThreeBytes.User.Role.List.Validations.Abstract
{
    public interface IRoleListRoleValidatorResolver
    {
        IValidator<RoleListRole> CreateValidator();
        IValidator<RoleListRole> RenameValidator();
    }
}
