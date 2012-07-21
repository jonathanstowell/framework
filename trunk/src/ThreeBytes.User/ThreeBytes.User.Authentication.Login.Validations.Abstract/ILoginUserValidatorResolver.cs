using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Validations.Abstract
{
    public interface ILoginUserValidatorResolver
    {
        IValidator<LoginUser> CreateValidator();
        IValidator<LoginUser> UpdateRolesValidator();
        IValidator<LoginUser> UpdatePasswordValidator();
        IValidator<LoginUser> UpdateEmailValidator();
        IValidator<LoginUser> UnlockUserValidator();
        IValidator<LoginUser> UserEnteredIncorrectPasswordValidator();
        IValidator<LoginUser> VerifyUserValidator();
        IValidator<LoginUser> AuthenticateUserValidator();
    }
}
