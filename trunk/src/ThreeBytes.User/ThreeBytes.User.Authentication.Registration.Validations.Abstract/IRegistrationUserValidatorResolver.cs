using FluentValidation;
using ThreeBytes.User.Authentication.Registration.Entities;

namespace ThreeBytes.User.Authentication.Registration.Validations.Abstract
{
    public interface IRegistrationUserValidatorResolver
    {
        IValidator<RegistrationUser> CreateValidator();
        IValidator<RegistrationUser> VerifyUserValidator();
        IValidator<RegistrationUser> UpdateEmailValidator();
    }
}
