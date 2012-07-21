using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Abstract
{
    public interface IAuthenticationUserManagementRoleValidatorResolver
    {
        IValidator<AuthenticationUserManagementRole> CreateValidator();
    }
}
