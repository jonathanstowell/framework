using FluentValidation;
using ThreeBytes.Email.Template.Widget.Entities;

namespace ThreeBytes.Email.Template.Widget.Validations.Abstract
{
    public interface IEmailTemplateWidgetTemplateValidatorResolver
    {
        IValidator<EmailTemplateWidgetTemplate> CreateValidator();
        IValidator<EmailTemplateWidgetTemplate> DeleteValidator();
        IValidator<EmailTemplateWidgetTemplate> RenameValidator();
    }
}
