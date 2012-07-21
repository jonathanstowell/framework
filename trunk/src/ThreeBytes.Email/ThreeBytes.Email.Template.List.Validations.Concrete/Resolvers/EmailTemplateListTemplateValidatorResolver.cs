using System;
using FluentValidation;
using ThreeBytes.Email.Template.List.Entities;
using ThreeBytes.Email.Template.List.Validations.Abstract;
using ThreeBytes.Email.Template.List.Validations.Concrete.Validators;

namespace ThreeBytes.Email.Template.List.Validations.Concrete.Resolvers
{
    public class EmailTemplateListTemplateValidatorResolver : IEmailTemplateListTemplateValidatorResolver
    {
        private readonly Func<CreateEmailTemplateListTemplateValidator> createEmailTemplateListTemplateValidator;
        private readonly Func<DeleteEmailTemplateListTemplateValidator> deleteEmailTemplateListTemplateValidator;
        private readonly Func<RenameEmailTemplateListTemplateValidator> renameEmailTemplateListTemplateValidator;
        private readonly Func<UpdateContentEmailTemplateListTemplateValidator> updateContentEmailTemplateListTemplateValidator;
        private readonly Func<UpdateFromAddressEmailTemplateListTemplateValidator> updateFromAddressEmailTemplateListTemplateValidator;

        public EmailTemplateListTemplateValidatorResolver(Func<CreateEmailTemplateListTemplateValidator> createEmailTemplateListTemplateValidator, Func<DeleteEmailTemplateListTemplateValidator> deleteEmailTemplateListTemplateValidator, Func<RenameEmailTemplateListTemplateValidator> renameEmailTemplateListTemplateValidator, Func<UpdateContentEmailTemplateListTemplateValidator> updateContentEmailTemplateListTemplateValidator, Func<UpdateFromAddressEmailTemplateListTemplateValidator> updateFromAddressEmailTemplateListTemplateValidator)
        {
            this.createEmailTemplateListTemplateValidator = createEmailTemplateListTemplateValidator;
            this.deleteEmailTemplateListTemplateValidator = deleteEmailTemplateListTemplateValidator;
            this.renameEmailTemplateListTemplateValidator = renameEmailTemplateListTemplateValidator;
            this.updateContentEmailTemplateListTemplateValidator = updateContentEmailTemplateListTemplateValidator;
            this.updateFromAddressEmailTemplateListTemplateValidator = updateFromAddressEmailTemplateListTemplateValidator;
        }

        public IValidator<EmailTemplateListTemplate> CreateValidator()
        {
            return createEmailTemplateListTemplateValidator();
        }

        public IValidator<EmailTemplateListTemplate> DeleteValidator()
        {
            return deleteEmailTemplateListTemplateValidator();
        }

        public IValidator<EmailTemplateListTemplate> RenameValidator()
        {
            return renameEmailTemplateListTemplateValidator();
        }

        public IValidator<EmailTemplateListTemplate> UpdateContentsValidator()
        {
            return updateContentEmailTemplateListTemplateValidator();
        }

        public IValidator<EmailTemplateListTemplate> UpdateFromAddressValidator()
        {
            return updateFromAddressEmailTemplateListTemplateValidator();
        }
    }
}
