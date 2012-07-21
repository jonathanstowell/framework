using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Abstract
{
    public interface IAuthenticationUserManagementUserValidatorResolver
    {
        IValidator<AuthenticationUserManagementUser> CreateValidator();
        IValidator<AuthenticationUserManagementUser> UnlockUserValidator();
        IValidator<AuthenticationUserManagementUser> VerifyUserValidator();
        IValidator<AuthenticationUserManagementUser> UpdateRolesValidator();
        IValidator<AuthenticationUserManagementUser> LockAuthenticationUserManagementUserOutValidator();
        IValidator<AuthenticationUserManagementUser> UpdateEmailValidator();
    }
}
