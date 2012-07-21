using FluentValidation;
using ThreeBytes.Email.Template.Management.Entities;

namespace ThreeBytes.Email.Template.Management.Validations.Abstract
{
    public interface IEmailTemplateManagementTemplateValidatorResolver
    {
        IValidator<EmailTemplateManagementTemplate> CreateValidator();
        IValidator<EmailTemplateManagementTemplate> DeleteValidator();
        IValidator<EmailTemplateManagementTemplate> RenameValidator();
        IValidator<EmailTemplateManagementTemplate> UpdateContentsValidator();
        IValidator<EmailTemplateManagementTemplate> UpdateFromAddressValidator();
    }
}
