using FluentValidation;
using ThreeBytes.User.Role.Management.Entities;

namespace ThreeBytes.User.Role.Management.Validations.Abstract
{
    public interface IRoleManagementRoleValidatorResolver
    {
        IValidator<RoleManagementRole> CreateValidator();
        IValidator<RoleManagementRole> RenameValidator();
    }
}
