using FluentValidation;
using ThreeBytes.User.Authentication.Password.Entities;

namespace ThreeBytes.User.Authentication.Password.Validations.Abstract
{
    public interface IPasswordManagementUserValidatorResolver
    {
        IValidator<PasswordManagementUser> CreateValidator();
        IValidator<PasswordManagementUser> UnlockUserValidator();
        IValidator<PasswordManagementUser> VerifyUserValidator();
        IValidator<PasswordManagementUser> ResetPasswordValidator();
        IValidator<PasswordManagementUser> ResetPasswordConfirmValidator();
        IValidator<PasswordManagementUser> LockPasswordManagementUserOutValidator();
        IValidator<PasswordManagementUser> UpdateEmailValidator();
    }
}
