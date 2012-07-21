using FluentValidation;
using ThreeBytes.Email.Dispatch.Widget.Entities;

namespace ThreeBytes.Email.Dispatch.Widget.Validations.Abstract
{
    public interface IEmailDispatchWidgetEmailMessageValidatorResolver
    {
        IValidator<EmailDispatchWidgetEmailMessage> CreateValidator();
    }
}
