using FluentValidation;
using ThreeBytes.Email.Dispatch.List.Entities;

namespace ThreeBytes.Email.Dispatch.List.Validations.Abstract
{
    public interface IEmailDispatchListEmailMessageValidatorResolver
    {
        IValidator<EmailDispatchListEmailMessage> CreateValidator();
    }
}
