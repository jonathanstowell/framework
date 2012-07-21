using FluentValidation;
using ThreeBytes.User.Authentication.Registration.Entities;

namespace ThreeBytes.User.Authentication.Registration.Validations.Abstract
{
    public interface IExternalUserValidatorResolver
    {
        IValidator<ExternalUser> CreateValidator();
        IValidator<ExternalUser> LinkExternalProviderValidator();
    }
}