using FluentValidation;
using ThreeBytes.Email.Template.List.Entities;

namespace ThreeBytes.Email.Template.List.Validations.Abstract
{
    public interface IEmailTemplateListTemplateValidatorResolver
    {
        IValidator<EmailTemplateListTemplate> CreateValidator();
        IValidator<EmailTemplateListTemplate> DeleteValidator();
        IValidator<EmailTemplateListTemplate> RenameValidator();
        IValidator<EmailTemplateListTemplate> UpdateContentsValidator();
        IValidator<EmailTemplateListTemplate> UpdateFromAddressValidator();
    }
}
