using System;
using FluentValidation;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Validations.Abstract;
using ThreeBytes.Email.Template.Management.Validations.Concrete.Validators;

namespace ThreeBytes.Email.Template.Management.Validations.Concrete.Resolvers
{
    public class EmailTemplateManagementTemplateValidatorResolver : IEmailTemplateManagementTemplateValidatorResolver
    {
        private readonly Func<CreateEmailTemplateManagementTemplateValidator> createEmailTemplateManagementTemplateValidator;
        private readonly Func<DeleteEmailTemplateManagementTemplateValidator> deleteEmailTemplateManagementTemplateValidator;
        private readonly Func<RenameEmailTemplateManagementTemplateValidator> renameEmailTemplateManagementTemplateValidator;
        private readonly Func<UpdateContentEmailTemplateManagementTemplateValidator> updateContentEmailTemplateManagementTemplateValidator;
        private readonly Func<UpdateFromAddressEmailTemplateManagementTemplateValidator> updateFromAddressEmailTemplateManagementTemplateValidator;

        public EmailTemplateManagementTemplateValidatorResolver(Func<CreateEmailTemplateManagementTemplateValidator> createEmailTemplateManagementTemplateValidator, Func<DeleteEmailTemplateManagementTemplateValidator> deleteEmailTemplateManagementTemplateValidator, Func<RenameEmailTemplateManagementTemplateValidator> renameEmailTemplateManagementTemplateValidator, Func<UpdateContentEmailTemplateManagementTemplateValidator> updateContentEmailTemplateManagementTemplateValidator, Func<UpdateFromAddressEmailTemplateManagementTemplateValidator> updateFromAddressEmailTemplateManagementTemplateValidator)
        {
            this.createEmailTemplateManagementTemplateValidator = createEmailTemplateManagementTemplateValidator;
            this.deleteEmailTemplateManagementTemplateValidator = deleteEmailTemplateManagementTemplateValidator;
            this.renameEmailTemplateManagementTemplateValidator = renameEmailTemplateManagementTemplateValidator;
            this.updateContentEmailTemplateManagementTemplateValidator = updateContentEmailTemplateManagementTemplateValidator;
            this.updateFromAddressEmailTemplateManagementTemplateValidator = updateFromAddressEmailTemplateManagementTemplateValidator;
        }

        public IValidator<EmailTemplateManagementTemplate> CreateValidator()
        {
            return createEmailTemplateManagementTemplateValidator();
        }

        public IValidator<EmailTemplateManagementTemplate> DeleteValidator()
        {
            return deleteEmailTemplateManagementTemplateValidator();
        }

        public IValidator<EmailTemplateManagementTemplate> RenameValidator()
        {
            return renameEmailTemplateManagementTemplateValidator();
        }

        public IValidator<EmailTemplateManagementTemplate> UpdateContentsValidator()
        {
            return updateContentEmailTemplateManagementTemplateValidator();
        }

        public IValidator<EmailTemplateManagementTemplate> UpdateFromAddressValidator()
        {
            return updateFromAddressEmailTemplateManagementTemplateValidator();
        }
    }
}
