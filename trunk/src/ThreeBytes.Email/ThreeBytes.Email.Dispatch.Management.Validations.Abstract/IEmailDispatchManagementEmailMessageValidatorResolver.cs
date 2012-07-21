using FluentValidation;
using ThreeBytes.Email.Dispatch.Management.Entities;

namespace ThreeBytes.Email.Dispatch.Management.Validations.Abstract
{
    public interface IEmailDispatchManagementEmailMessageValidatorResolver
    {
        IValidator<EmailDispatchManagementEmailMessage> SendValidator();
    }
}
