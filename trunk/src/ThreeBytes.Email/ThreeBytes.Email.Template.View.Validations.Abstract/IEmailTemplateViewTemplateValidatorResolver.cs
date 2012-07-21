using FluentValidation;
using ThreeBytes.Email.Template.View.Entities;

namespace ThreeBytes.Email.Template.View.Validations.Abstract
{
    public interface IEmailTemplateViewTemplateValidatorResolver
    {
        IValidator<EmailTemplateViewTemplate> CreateValidator();
        IValidator<EmailTemplateViewTemplate> DeleteValidator();
        IValidator<EmailTemplateViewTemplate> RenameValidator();
        IValidator<EmailTemplateViewTemplate> UpdateContentsValidator();
        IValidator<EmailTemplateViewTemplate> UpdateFromAddressValidator();
    }
}
