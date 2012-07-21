using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Validations.Abstract
{
    public interface ILoginRoleValidatorResolver
    {
        IValidator<LoginRole> CreateValidator();
    }
}
