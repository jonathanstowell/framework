using System;
using FluentValidation;
using ThreeBytes.Email.Template.View.Entities;
using ThreeBytes.Email.Template.View.Validations.Abstract;
using ThreeBytes.Email.Template.View.Validations.Concrete.Validators;

namespace ThreeBytes.Email.Template.View.Validations.Concrete.Resolvers
{
    public class EmailTemplateViewTemplateValidatorResolver : IEmailTemplateViewTemplateValidatorResolver
    {
        private readonly Func<CreateEmailViewManagementTemplateValidator> createEmailTemplateViewTemplateValidator;
        private readonly Func<DeleteEmailTemplateViewTemplateValidator> deleteEmailTemplateViewTemplateValidator;
        private readonly Func<RenameEmailTemplateViewTemplateValidator> renameEmailTemplateViewTemplateValidator;
        private readonly Func<UpdateContentEmailTemplateViewTemplateValidator> updateContentEmailTemplateViewTemplateValidator;
        private readonly Func<UpdateFromAddressEmailTemplateViewTemplateValidator> updateFromAddressEmailTemplateViewTemplateValidator;

        public EmailTemplateViewTemplateValidatorResolver(Func<CreateEmailViewManagementTemplateValidator> createEmailTemplateViewTemplateValidator, Func<DeleteEmailTemplateViewTemplateValidator> deleteEmailTemplateViewTemplateValidator, Func<RenameEmailTemplateViewTemplateValidator> renameEmailTemplateViewTemplateValidator, Func<UpdateContentEmailTemplateViewTemplateValidator> updateContentEmailTemplateViewTemplateValidator, Func<UpdateFromAddressEmailTemplateViewTemplateValidator> updateFromAddressEmailTemplateViewTemplateValidator)
        {
            this.createEmailTemplateViewTemplateValidator = createEmailTemplateViewTemplateValidator;
            this.deleteEmailTemplateViewTemplateValidator = deleteEmailTemplateViewTemplateValidator;
            this.renameEmailTemplateViewTemplateValidator = renameEmailTemplateViewTemplateValidator;
            this.updateContentEmailTemplateViewTemplateValidator = updateContentEmailTemplateViewTemplateValidator;
            this.updateFromAddressEmailTemplateViewTemplateValidator = updateFromAddressEmailTemplateViewTemplateValidator;
        }

        public IValidator<EmailTemplateViewTemplate> CreateValidator()
        {
            return createEmailTemplateViewTemplateValidator();
        }

        public IValidator<EmailTemplateViewTemplate> DeleteValidator()
        {
            return deleteEmailTemplateViewTemplateValidator();
        }

        public IValidator<EmailTemplateViewTemplate> RenameValidator()
        {
            return renameEmailTemplateViewTemplateValidator();
        }

        public IValidator<EmailTemplateViewTemplate> UpdateContentsValidator()
        {
            return updateContentEmailTemplateViewTemplateValidator();
        }

        public IValidator<EmailTemplateViewTemplate> UpdateFromAddressValidator()
        {
            return updateFromAddressEmailTemplateViewTemplateValidator();
        }
    }
}
