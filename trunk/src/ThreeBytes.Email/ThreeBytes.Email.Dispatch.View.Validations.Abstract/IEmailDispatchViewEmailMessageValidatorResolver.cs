using FluentValidation;
using ThreeBytes.Email.Dispatch.View.Entities;

namespace ThreeBytes.Email.Dispatch.View.Validations.Abstract
{
    public interface IEmailDispatchViewEmailMessageValidatorResolver
    {
        IValidator<EmailDispatchViewEmailMessage> CreateValidator();
    }
}
